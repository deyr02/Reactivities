export interface Duck {
    name: string;
    numLegs: number;
    makeSound: (sound:string)=> void;
    
}


const duck1:Duck ={
    name: "huey",
    numLegs: 2, 
    makeSound: (sound:number|string) => console.log(sound)
}
const duck2:Duck ={
    name: "Dewey",
    numLegs: 2, 
    makeSound: (sound:any) => console.log(sound)
}

duck2.makeSound("quack");

export const ducks = [duck1, duck2]