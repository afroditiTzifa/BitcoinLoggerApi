import { Component, OnInit } from '@angular/core';
import { IBitcoinPrice} from './bitcoin-price';
import { IBitcoinSource} from './bitcoin-source';
import { NewDataService } from './new-data.service';


@Component({
  templateUrl: './new-data.component.html',
})

export class NewDataComponent implements OnInit {
   
  errorMessage: string;
  bitcoinPrice: IBitcoinPrice;
  bitcoinSources :IBitcoinSource[];
  

  constructor(private srv: NewDataService) { } 


  ngOnInit()
  {  
    
    this.srv.getBitcoinSources().subscribe(
      {
        next:response=> this.bitcoinSources=response, 
        error: err=>this.errorMessage=err
       }
      );
  }


  onClick(sourceId: number){
console.log(sourceId);
    this.srv.getBitcoinPrice(sourceId).subscribe(
        {
          next:response=> {this.bitcoinPrice=response;  
                           let fetchedData ="price: ".concat(this.bitcoinPrice.price.toFixed(2).toString()).concat(" ,timestamp: ").concat(this.bitcoinPrice.timestamp.toString());
                           this.bitcoinSources.find(x => x.id === sourceId).fetchedData = fetchedData;}, 
          error: err=>this.errorMessage=err
        }
        );

    

  }  


}



