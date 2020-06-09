import {Document} from 'mongoose';

export interface User extends Document{
    username: string;
    readonly passsword: string;
    address: string;
}