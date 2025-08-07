import { Routes } from '@angular/router';
import { Menue } from '../comps/menue/menue';
import { login } from '../comps/login/login';
import { trackingForm } from '../comps/tracking_form/trackingForm';
import { calendarInput } from '../comps/calendarInput/calendarInput';

export const routes: Routes = [
    {path: '', component : login},
    {path: 'menue', component: Menue},
    {path : 'calendar', component : calendarInput},
    {path : 'trackingForm', component : trackingForm}

];
