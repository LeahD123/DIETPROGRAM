import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FoodsItem } from "../classes/FoodsItem";
//אל הBACKEND נשלח מהקומפוננטות
@Injectable({
    providedIn: 'root'
})
export class foodsItemService {
    basicUrl: string = 'http://localhost:5076/api';

    constructor(public req: HttpClient) { }

    getByCategoryAndCalories(category: string, cal: number): Observable<Array<FoodsItem>> {
        return this.req.get<Array<FoodsItem>>(`${this.basicUrl}/foodsItem/category/${category}/calories/${cal}`);
    }
}
