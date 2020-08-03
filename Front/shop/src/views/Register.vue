<template>
 <transition name="fade">
<div class="loginBody" >
            <div class=" register pl-4 pr-4">
                <div class="row ">
                    <div class="col-12 text-center ">
                 <router-link to="/"><img src="..\assets\img\1200px-Логотип_МИЭМ.svg.png" id="miem" style="width:200px" class="  "/></router-link>
                 </div>
                </div>
                
                <div class="mymenu2 forma2 p-4">
                  <div class="text-center">
                      <span  class="curs " style="color:rgb(88,89,91);font-size:30px"><strong>Регистрация</strong></span>
                  </div>

<div style="position:relative">
  <form class="was-validated" @submit.prevent="Register" style="font-size:15px">
  <div class="mb-3">
    <label for="validationTextarea3" style="font-size:15px">Name</label>
    <input class="form-control is-invalid" id="validationTextarea3" v-model="formLog.name" style="font-size:15px" placeholder="Ivan" required>
    
  </div>

  <div class="mb-3">
    <label for="validationTextarea4" style="font-size:15px">Email</label>
    <input type="email" class="form-control is-invalid" v-model="formLog.email" id="validationTextarea4" style="font-size:15px" placeholder="example@edu.hse.ru" required>
    
  </div>

  <div class="mb-3">
    <label for="validationTextarea5" style="font-size:15px">Password</label>
    <input class="form-control is-invalid" type="password" v-model="formLog.password" id="validationTextarea5"  style="font-size:15px" placeholder="example1234" required>
    <div class="invalid-feedback" style="color:rgb(88,89,91)">Минимум 8 симв. , должен  содержать цифры </div>
  </div>

  <div class="custom-control custom-checkbox mb-3">
    <input type="checkbox" class="custom-control-input" id="customControlValidation1" required>
    <label class="custom-control-label" for="customControlValidation1">Я не робот</label>
  </div>

 <div class="text-center">
<button type="submit" class="btn btn-lg btn-warning" style="color:white;font-size:25px;"><strong> Зарегистрироваться</strong></button>
  </div>
  <div class="text-center mt-3">
<router-link to="/login"><span  class="curs sort " style="font-size:15px"><strong>Войти</strong></span></router-link>
  </div>

</form>
 </div>
</div>
               
               
            </div>
            
      

</div>
 </transition >
</template>

<script>

function check_for_number(str)
{
    let lenght =str.length; 
    for(let i=0;i<lenght;)
    {
        if (Number.isInteger(+str[i++]))
        {
            return true;
        }
    }
    return false;
}
import swal from 'sweetalert'
export default {
  data(){
    return{
      formLog:{
        name:"",
        email:"",
        password:""
      },
      AllAboutToken:null
    }
  },
  methods:{
     Register(){
           
            const data={
                "name":this.formLog.name,
                "email": this.formLog.email,
                "password": this.formLog.password};
                if(this.formLog.password.length >=8 && check_for_number(this.formLog.password) ){
                  
                  this.$store.dispatch('Register',data)
                 
                 
                }
                else{
                   swal({
                    text: "Пароль не надежный",
                    icon: "warning",
      });
                }
        },

  }


}
</script>





<style scoped>

.loginBody{
width: 100%;
    height: 100%;
    position: fixed;
    top: 0;
    left: 0;
    display: flex;
    align-items: center;
    align-content: center; 
    justify-content: center; 
    overflow: auto;
}
.register{
  display: block;
  width: 400px;
  height: 500px;
}
.forma2{
   width: 100%;
  height: 440px; 
}
</style>