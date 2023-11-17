import {Injectable} from '@angular/core';
import {RegisterDTO} from "./RegisterDTO";
import {lastValueFrom} from "rxjs";
import {HttpClient, HttpHandler} from "@angular/common/http";
import {LoginDTO} from "./LoginDTO";
import {Voyage} from "./Voyage";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  public domain: string = 'https://localhost:7023/';

  constructor(public http:HttpClient) {
  }

  async SignUp(DTO:RegisterDTO):Promise<void>{
    let res = await lastValueFrom(this.http.post<any>(this.domain + 'api/Users/Register', DTO))
    localStorage["token"] = res.token;
  }

  async LogIn(DTO:LoginDTO):Promise<void>{
    let res = await lastValueFrom(this.http.post<any>(this.domain + 'api/Users/Login', DTO))
    localStorage["token"] = res.token;
  }

  async GetAllVoyages():Promise<Voyage[]>{
    let res :Voyage[] = await lastValueFrom(this.http.get<Voyage[]>(this.domain + "api/Voyages"));
    return res;
  }
}
