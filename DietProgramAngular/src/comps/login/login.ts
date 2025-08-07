import { ApplicationModule, Component, NgModule } from "@angular/core";
import { Router } from "@angular/router";
import { userService } from "../../services/user.services"; 
import { User } from "../../classes/User";
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'login',
    standalone: true,
    templateUrl: './login.html',
    imports :[FormsModule],
    styleUrls: ['./login.css']
})
export class login {
    email : string = "";
    password : string = ""

    constructor(public userService: userService, public router: Router) { }

    onSubmit(email : string, password : string) {

        this.userService.login(email, password).subscribe((user: User | undefined) => {
            if (user) {
                localStorage.setItem('firstName', JSON.stringify(user.firstName));
                localStorage.setItem('lastName', JSON.stringify(user.lastName));
                localStorage.setItem('email', JSON.stringify(user.email));
                localStorage.setItem('BMI', JSON.stringify(user.BMI));
                localStorage.setItem('cal per day',JSON.stringify(user.calPerDay));
                //לעדכן את כמות הימים שנותרו כל פעם
                localStorage.setItem('day for diet',JSON.stringify(user.dayForDiet))
                localStorage.setItem('height',JSON.stringify(user.height));
                localStorage.setItem('weight',JSON.stringify(user.weight))
                localStorage.setItem('wish Weight',JSON.stringify(user.wishWeight))
                // localStorage.setItem('cal to loss', JSON.stringify(user.calToLoss))
                this.router.navigate(['/menue']);
            } else {
                console.error("the user unexsist!");
            }
        });
    }
}
