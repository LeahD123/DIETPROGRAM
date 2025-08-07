import { Component, OnInit } from "@angular/core";
import { Router, RouterOutlet } from "@angular/router";
import { CommonModule } from "@angular/common";
@Component({
    selector: 'trackingForm',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './trackingForm.html',
    styleUrls: ['./trackingForm.css']
})

export class trackingForm implements OnInit{
fruit1: string = localStorage.getItem('fruits1')!;
fruit2 : string =  localStorage.getItem('fruits2')!;
fruit3 : string  = localStorage.getItem('fruits3')!;
crab1 : string =  localStorage.getItem('crab1')!;
crab2 : string =  localStorage.getItem('crab2')!;
crab3 : string =  localStorage.getItem('crab3')!;
protein1 : string =  localStorage.getItem('protein1')!;
protein2 : string =  localStorage.getItem('protein2')!;
protein3 : string =  localStorage.getItem('protein3')!;
ngOnInit(): void {
    
}
}
