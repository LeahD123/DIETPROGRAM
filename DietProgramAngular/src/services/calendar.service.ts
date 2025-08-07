import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import {Calendar} from "../classes/Calendar";
//אל הBACKEND נשלח מהקומפוננטות
@Injectable({
    providedIn: 'root'
})
export class calendarService {
    basicUrl: string = 'http://localhost:5076/api';

    constructor(public req: HttpClient) { }
    getcalendarItems() : Observable<Array<Calendar>> {
        return this.req.get<Array<Calendar>>(`${this.basicUrl}/calendar`);
    }
    addCalendarItem(calendarItem: Calendar): Observable<Calendar> {
        return this.req.post<Calendar>(`${this.basicUrl}/calendar`, calendarItem);
    }
    updateCalendarItem(calendarItem: Calendar): Observable<Calendar> {
        return this.req.put<Calendar>(`${this.basicUrl}/calendar/${calendarItem.userId}`, calendarItem);
    }
    deleteCalendarItem(userId: number): Observable<void> {
        return this.req.delete<void>(`${this.basicUrl}/calendar/${userId}`);
    }
}
