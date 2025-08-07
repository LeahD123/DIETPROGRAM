import { Component, OnInit } from '@angular/core';
import { calendar } from '../calender/calendar';
import { CommonModule } from '@angular/common';

@Component({
    selector : "calendarInput",
    imports: [CommonModule, calendar],
    standalone: true,
    templateUrl: './calendarInput.html',
    styleUrl : './calendarInput.css'
})

export class calendarInput implements OnInit{
month! : number;
year! : number;
day ! : number;
dayOfWeek ! : number;
    ngOnInit(): void {
        const data: Date= new Date()
        console.log(data);
        this.month = data.getMonth()
        console.log(this.month);
        this.year = data.getFullYear()
                console.log(this.year);
        this.day = data.getDate();
                console.log(this.day);
        this.dayOfWeek = data.getDay()
                console.log(this.dayOfWeek);
    }
}