export class Sport{
    constructor(id : number,
        public type: string ,
        public name?: string,
        public description?: string,
        public loseCalPerHour?:number
){}
}