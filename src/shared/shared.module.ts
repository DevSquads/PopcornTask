import { Module } from '@nestjs/common';
import { UserService } from './user/user.service';
import { APP_FILTER, APP_INTERCEPTOR } from '@nestjs/core';
import { MongooseModule } from '@nestjs/mongoose';

import { UserSchema } from '../models/user.schema';
import { HttpExceptionFilter } from './http-exception.filter';

@Module({
    imports: [MongooseModule.forFeature([{ name: 'User', schema: UserSchema }])],
    
  providers: [UserService],
  exports: [UserService]
})
export class SharedModule {}
