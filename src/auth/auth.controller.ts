import { Controller, Post, Body, Get, UseGuards } from '@nestjs/common';
import { UserService } from 'src/shared/user/user.service';
import { RegisterDTO, LoginDTO } from './auth.dto';
import { AuthGuard } from '@nestjs/passport';
import { AuthService } from './auth.service';

@Controller('auth')
export class AuthController {
    constructor(private userService: UserService, 
        private authService: AuthService ){
      
    }

    @Get()
@UseGuards(AuthGuard('jwt'))
tempAuth(){
    return {auth: 'works'};
}

    @Post('login')
    async login(@Body() userDTO: LoginDTO){
        console.log('UserDTO ',userDTO);
        const user =  await this.userService.findByLogin(userDTO);
        console.log('user', user);
        const payload = {
            username: user.username,

        }
        const token = await this.authService.signPayload(payload);
        return {user, token};
    }

    @Post('register')
    async register(@Body() userDTO: RegisterDTO){
        console.log('UserDTO',userDTO);
        const user = await this.userService.create(userDTO);
        console.log('user',user);
        const payload = {
            username: user.username,
            address: user.address,

        }
        const token = await this.authService.signPayload(payload);
        return {user, token};
    }

}
