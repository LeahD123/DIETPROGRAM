import { Component, OnInit } from "@angular/core";
import { FoodsItem } from "../../classes/FoodsItem";
import {foodsItemService } from '../../services/foodsItem.service'
import { Sport } from "../../classes/Sport";
import { Router, RouterOutlet } from "@angular/router";
import { CommonModule } from "@angular/common";
import { sportService } from "../../services/Sport.service";
@Component({
    selector: 'Menue',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './menue.html',
    styleUrls: ['./menue.css']
})

export class Menue {
    constructor(
        public router: Router,
        public foodsItemService: foodsItemService,
        public sportService: sportService
    ) { }
    allFruits1: Array<FoodsItem> = [];
    allFruits2: Array<FoodsItem> = [];
    allFruits3: Array<FoodsItem> = [];
    allCrabs1: Array<FoodsItem> = [];
    allCrabs2: Array<FoodsItem> = [];
    allCrabs3: Array<FoodsItem> = [];
    allProteins1: Array<FoodsItem> = [];
    allProteins2: Array<FoodsItem> = [];
    allProteins3: Array<FoodsItem> = [];
    allSportAction: Array<Sport> = [];
    ngOnInit() : void {
        // const calToLoss : number = parseFloat(localStorage.getItem('cal to loss')!);
        const calPerBreakfast : number = parseFloat(localStorage.getItem('cal per day')!) / 3 + 50;
        const calPerLunch : number = parseFloat(localStorage.getItem('cal per day')!) / 3 + 100;
        const calPerEvning : number = parseFloat(localStorage.getItem('cal per day')!)/3 - 150;
        try {
            this.foodsItemService.getByCategoryAndCalories('fruits', (calPerBreakfast/3)).subscribe(data => {
                this.allFruits1 = data;
                localStorage.setItem("fruit1", JSON.stringify(data))
            });
            this.foodsItemService.getByCategoryAndCalories('fruits', (calPerLunch/3)).subscribe(data => {
                this.allFruits2 = data;
                localStorage.setItem("fruit2", JSON.stringify(data))
            });
            this.foodsItemService.getByCategoryAndCalories('fruits',  (calPerEvning/3)).subscribe(data => {
                this.allFruits3 = data;
                localStorage.setItem("fruit3", JSON.stringify(data))
            });
            this.foodsItemService.getByCategoryAndCalories('crab', (calPerBreakfast/3)).subscribe(data => {
                this.allCrabs1 = data;
                localStorage.setItem("crab1", JSON.stringify(data))
            });
            this.foodsItemService.getByCategoryAndCalories('crab',  (calPerLunch/3)).subscribe(data => {
                this.allCrabs2 = data;
                localStorage.setItem("crab2", JSON.stringify(data))
            });
            this.foodsItemService.getByCategoryAndCalories('crab', (calPerEvning/3)).subscribe(data => {
                this.allCrabs3 = data;
                localStorage.setItem("crab3", JSON.stringify(data))
            });
            this.foodsItemService.getByCategoryAndCalories('protein', (calPerBreakfast/3)).subscribe(data => {
                this.allProteins1 = data;
                localStorage.setItem("protein", JSON.stringify(data))
            });
            this.foodsItemService.getByCategoryAndCalories('protein',  (calPerLunch/3)).subscribe(data => {
                this.allProteins2 = data;
                localStorage.setItem("fruit1", JSON.stringify(data))
            });
            this.foodsItemService.getByCategoryAndCalories('protein', (calPerEvning/3)).subscribe(data => {
                this.allProteins3 = data;
                localStorage.setItem("fruit1", JSON.stringify(data))
            });
            this.sportService.GetByLoseCal(500).subscribe(data => {
                this.allSportAction = data;
                localStorage.setItem("fruit1", JSON.stringify(data))
            });
        } catch (error) {
            console.error("Error occurred:", error);
        }
    }
}
