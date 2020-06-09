import {Document} from 'mongoose';


export interface Popcorn extends Document{
    type: string;
    description: string;
    price: string;
    image: string;
}