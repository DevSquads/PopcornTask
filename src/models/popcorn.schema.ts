import * as mongoose from 'mongoose';

export const PopcornSchema = new mongoose.Schema({
    type: String,
    description: String,
    price: String,
    image: String
});
