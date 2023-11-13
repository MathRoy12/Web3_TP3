import {Injectable} from '@angular/core';
import {RegisterDTO} from "./RegisterDTO";
import {lastValueFrom} from "rxjs";
import {HttpClient, HttpHandler} from "@angular/common/http";
import {LoginDTO} from "./LoginDTO";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  public domain: string = 'https://localhost:7023/';

  constructor(public http:HttpClient) {
  }

  async SignUp(DTO:RegisterDTO){
    let res = await lastValueFrom(this.http.post<any>(this.domain + 'api/Users/Register', DTO))
    localStorage["token"] = res.token;
  }

  async LogIn(DTO:LoginDTO){
    let res = await lastValueFrom(this.http.post<any>(this.domain + 'api/Users/Login', DTO))
    localStorage["token"] = res.token;
  }
}
