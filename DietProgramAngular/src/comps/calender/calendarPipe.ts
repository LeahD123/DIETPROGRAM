import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'monthName',
})
export class monthName implements PipeTransform {

  transform(month: number): string {
    const monthes = [
        'ינואר',
        'פבואר',
        'מרץ',
        'אפריל',
        'מאי',
        'יוני',
        'יולי',
        'אוגוסט',
        'ספטמבר',
        'אוקטובר',
        'נובמבר',
        'דצמבר'
    ]
    return monthes[month]

}

}

@Pipe({
  name: 'DayOfWeekName'
})
export class DayOfWeekName implements PipeTransform {

  transform(dayOfWeek: number): string {
    const days = [
        'ראשון',
        'שני',
        'שלישי',
        'רביעי',
        'חמישי',
        'שישי',
        'שבת'
    ]
    return days[dayOfWeek]

}

}