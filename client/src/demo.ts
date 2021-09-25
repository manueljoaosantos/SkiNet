//let data = 42;// inicializa com number
let data: any;// inicializa com qualquer tipo

interface ICar {
  color: string;
  model: string;
  topSpeed?: number;
};

const car1: ICar={
  color: 'azul',
  model: 'bmw'
};

const car2: ICar={
  color: 'vermelho',
  model: 'mercedes',
  topSpeed: 100
};

console.trace(car1.model);

// Função
const multiply = (x: any, y: any): number => {
  return x * y;
};
 
const multiply1 = (x: any, y: any): void => {
  x * y;
};

const multiply2 = (x: number, y: number): string => {
  return (x * y).toString();
};

