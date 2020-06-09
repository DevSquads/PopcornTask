import * as mongoose from 'mongoose'

export const OrderSchema = new mongoose.Schema({
owner:{
    type: mongoose.Schema.Types.ObjectId,
    ref: 'User'
},
totalPrice: {
    type: Number,
    default: 0
},
popcorns:[
    {
        popcorn:{
            type: mongoose.Schema.Types.ObjectId,
            ref: 'Popcorn',
        },
        quantity: {
            type: Number,
            default: 0
        }
    }
]
   
});