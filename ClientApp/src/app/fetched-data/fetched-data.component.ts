import { Component, OnInit, ViewChild } from '@angular/core';
import { IBitcoinFetchedData} from './bitcoin-fetched-data';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatSort } from '@angular/material';
import { FetchedDataService } from './fetched-data.service';

@Component({
  templateUrl: './fetched-data.component.html'
})
export class FetchedDataComponent  implements OnInit{
  bitcoinFetchedData: IBitcoinFetchedData[];
  errorMessage: string;
  displayedColumns: string[] = ['source', 'price', 'timestamp'];
  dataSource  = new MatTableDataSource(this.bitcoinFetchedData);

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  constructor(private srv: FetchedDataService)  { }


  ngOnInit()
  {

    this.srv.getFetchedData().subscribe(
      {
       next:response=> 
          { this.bitcoinFetchedData=response;
            this.dataSource=new MatTableDataSource(this.bitcoinFetchedData);
            this.dataSource.paginator =this.paginator;
            this.dataSource.sort = this.sort;
          }, 
          error: err=>this.errorMessage=err
       }
      );

  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }







}


