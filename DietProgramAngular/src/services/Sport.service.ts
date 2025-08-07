import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { Sport } from "../classes/Sport";

@Injectable({
    providedIn: 'root'
})

export class sportService {
    basicUrl: string = "";
    constructor(public req: HttpClient) { }
GetByLoseCal(cal: number) : Observable<Array<Sport>> {
  const params = {cal}
  return this.req.post<Array<Sport>>(`${this.basicUrl}/sport`,{params});
}
}