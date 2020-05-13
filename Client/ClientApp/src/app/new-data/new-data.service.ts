import { Injectable, ɵConsole } from '@angular/core';
import { IBitcoinSource } from './bitcoin-source';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { tap, catchError} from 'rxjs/operators';
import { IBitcoinPrice } from './bitcoin-price';


@Injectable({
  providedIn: 'root'
})
export class NewDataService {

  constructor(private http:HttpClient) { }


  getBitcoinSources(): Observable<IBitcoinSource[]>{
    return this.http.get<IBitcoinSource[]>("https://bitcoinloggerapi.azurewebsites.net/sources").pipe(
      tap(data=>console.log('All: '+JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  
  getBitcoinPrice(sourceId: number): Observable<IBitcoinPrice>{
    console.log(sourceId);
    return this.http.get<IBitcoinPrice>("https://bitcoinloggerapi.azurewebsites.net/Prices/"+sourceId.toString()).pipe(
      tap(data=>console.log('All: '+JSON.stringify(data))),
      catchError(this.handleError)
    );
  }



  private handleError(err : HttpErrorResponse){
    let errorMessage='';
    if (err.error instanceof ErrorEvent)  {
      errorMessage= `An error occured: ${err.error.message}`;
    }
    else{
      errorMessage=`Server returned code: ${err.status}, error message is: ${err.error.message}`
    }
    console.error(errorMessage)
    return throwError(errorMessage);
  }
}
