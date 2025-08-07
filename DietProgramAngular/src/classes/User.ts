export class User{
    constructor(id:number, public firstName: string, public lastName: string, public email: string
        , public password: string, public calPerDay: number, public BMI: number, public weight: number,
        public height: number,public calToLoss : number, public wishWeight: number, public dayForDiet?:number
    ) {}
}