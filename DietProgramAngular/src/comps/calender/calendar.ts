import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { DayOfWeekName, monthName } from './calendarPipe';
import { CommonModule } from '@angular/common';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { FormControl, FormGroup } from '@angular/forms';
import { calendarService } from '../../services/calendar.service';
import { Calendar } from '../../classes/Calendar';


@Component({
    selector: 'calendar',
    imports: [CommonModule, monthName, DayOfWeekName],
    templateUrl: './calendar.html',
    styleUrls: ['./calendar.css'],
    encapsulation: ViewEncapsulation.None // הוסף כאן
})
export class calendar implements OnInit {
    @Input() month!: number;
    @Input() year!: number;
    @Input() day!: number;
    @Input() dayOfWeek!: number;
    itemsList: Array<Calendar> = []; // הגדרת רשימה לאחסון הנתונים

    myForm: FormGroup = new FormGroup({}); // הוסף את ה-FormGroup
    constructor(private sanitizer: DomSanitizer ,public calendarService: calendarService) {} // הוסף את DomSanitizer לקונסטרקטור
    ngOnInit(): void {
        this.restartFrom();
        this.calendarHtml = this.sanitizer.bypassSecurityTrustHtml(this.generateCalendar()); // עדכן את המשתנה עם התוצאה
        console.log(this.calendarHtml.toString()); // הוסף כאן לוג לבדוק את התוצאה
    }
restartFrom() {
    this.myForm = new FormGroup({
        month: new FormControl(new Date().getMonth()),
        year: new FormControl(new Date().getFullYear()),
        day: new FormControl(new Date().getDate()),
        dayOfWeek: new FormControl(new Date().getDay()),
        items: new FormControl(this.itemsList) // הוסף את itemsList כערך לשדה items

    });

    this.calendarService.getcalendarItems().subscribe(
        (items: Array<Calendar>) => {
            this.itemsList = items; // שמירת כל הנתונים ברשימה
            this.myForm.patchValue({ items: this.itemsList }); // עדכון הערך של items ב-FormGroup
        },
        (error) => {
            console.error('Error fetching calendar items:', error);
        }
    );
}
    generateCalendar() {
    const thisDay = new Date();
    let calendarHtml = `<section class="calendar__top-bar">
      <span class="top-bar__days">Mon</span>
      <span class="top-bar__days">Tue</span>
      <span class="top-bar__days">Wed</span>
      <span class="top-bar__days">Thu</span>
      <span class="top-bar__days">Fri</span>
      <span class="top-bar__days">Sat</span>
      <span class="top-bar__days">Sun</span>
    </section><section class="calendar__week">`;
    
    let isWeek: number = 0;
    const firstDayOfMonth = new Date(thisDay.getFullYear(), thisDay.getMonth(), 1);
    const lastDayOfMonth = new Date(thisDay.getFullYear(), thisDay.getMonth() + 1, 0);
    const daysInCurrentMonth = lastDayOfMonth.getDate();
    const firstDayOfWeek = firstDayOfMonth.getDay();
    const daysFromPreviousMonth = firstDayOfWeek - 1;
    const previousMonthDays = new Date(thisDay.getFullYear(), thisDay.getMonth(), 0).getDate();
    const firstDayAtCalendar = previousMonthDays - daysFromPreviousMonth;
    const totalDaysInCalendar = 35;
    const daysNeededAfter = totalDaysInCalendar - (daysInCurrentMonth + daysFromPreviousMonth);

    // מילוי הימים מהחודש הקודם
    for (let days = 0; days < daysFromPreviousMonth; days++) {
        if (isWeek == 7) {
            calendarHtml += `</section><section class="calendar__week">`;
            isWeek = 0;
        }
        calendarHtml += `<div class="calendar__day inactive">
                            <span class="calendar__date">${firstDayAtCalendar + days}</span>
                        </div>`;
        isWeek += 1;
    }

    // מילוי הימים מהחודש הנוכחי
    for (let days = 0; days < daysInCurrentMonth; days++) {
        const successItem = this.itemsList.find(item => {
            const itemDateStr = (item.Date instanceof Date)
                ? item.Date.toISOString().split('T')[0]
                : item.Date;
            return itemDateStr === new Date(thisDay.getFullYear(), thisDay.getMonth(), days + 1).toISOString().split('T')[0];
        });
        let className = '';

        if (successItem) {
            className = successItem.sucsess ? 'success' : 'failure';
        }

        if (isWeek == 7) {
            calendarHtml += `</section><section class="calendar__week">`;
            isWeek = 0;
        }

        if (days + 1 == thisDay.getDate()) {
            calendarHtml += `<div class="calendar__day today ${className}">
                                <span class="calendar__date">${days + 1}</span>
                            </div>`;
        } else {
            calendarHtml += `<div class="calendar__day ${className}">
                                <span class="calendar__date">${days + 1}</span>
                            </div>`;
        }
        isWeek += 1;
    }

    // מילוי הימים מהחודש הבא
    for (let days = 0; days < daysNeededAfter; days++) {
        if (isWeek == 7) {
            calendarHtml += `</section><section class="calendar__week">`;
            isWeek = 0;
        }
        calendarHtml += `<div class="calendar__day inactive">
                            <span class="calendar__date">${days + 1}</span>
                        </div>`;
        isWeek += 1;
    }

    return calendarHtml;
}
        calendarHtml: SafeHtml = "";
}
