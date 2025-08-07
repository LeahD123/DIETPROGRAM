import { HttpClient } from "@angular/common/http";
import { catchError, Observable, tap } from "rxjs";
import { Injectable } from "@angular/core";
import { User } from "../classes/User";

@Injectable({
    providedIn: 'root'
})
export class userService {
    basicUrl: string = 'http://localhost:5076/api';

    constructor(public req: HttpClient) { }

    login(email: string, password: string): Observable<User> {
        const body = { email, password };
        return this.req.post<User>(`${this.basicUrl}/User/login`, body)
        .pipe(
            tap(response => console.log("Response:", response)),
            catchError(error => {
                console.error("Login error:", error);
                throw new Error("Cannot found! 404!");
            })
        );
    }

}
