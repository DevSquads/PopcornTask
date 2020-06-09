import {Document} from 'mongoose';
import { User } from './user';
import { Popcorn } from './popcorn';

interface PopcornOrder {
    popcorn: Popcorn;
    quantity: number;
}
export interface Order extends Document{
    owner: User;
    totalPrice: number;
    popcorns: PopcornOrder[];
}