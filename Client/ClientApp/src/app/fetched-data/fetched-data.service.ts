import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IBitcoinFetchedData } from './bitcoin-fetched-data';

@Injectable({
  providedIn: 'root'
})
export class FetchedDataService {

  constructor(private http : HttpClient) { }

  getFetchedData(){
   return this.http.get<IBitcoinFetchedData[]>("https://bitcoinloggerapi.azurewebsites.net/Prices");
  }


}
