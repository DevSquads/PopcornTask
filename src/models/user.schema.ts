import * as mongoose from 'mongoose';
import * as bcrypt from 'bcrypt'
import { RequestTimeoutException } from '@nestjs/common';
export const UserSchema = new mongoose.Schema({
username: String,
password: String,
address: String
});
UserSchema.pre('save',async function(next:mongoose.HookNextFunction){
    try{
        if (!this.isModified('password')){
            return next();
        }
        const hashed = await bcrypt.hash(this['password'],10);
        this['password']=hashed;
        return next();

        }
        catch(err){
            return next(err);
        }
})