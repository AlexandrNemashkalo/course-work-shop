<template>
 <transition name="fade">
<div class="loginBody" >
            <div class=" login pl-4 pr-4">
                <div class="row ">
                    <div class="col-12 text-center ">
                 <router-link to="/"><img src="..\assets\img\1200px-Логотип_МИЭМ.svg.png" id="miem" style="width:200px" class="  "/></router-link>
                 </div>
                </div>
                
                <div class="mymenu2 forma p-4 pb-5">
                  <div class="text-center">
                      <span  class="curs " style="color:rgb(88,89,91);font-size:30px"><strong>Вход</strong></span>
                  </div>

<div style="position:relative">
  <form class="was-validated" @submit.prevent="Login" style="font-size:15px">
  
  <div class="mb-3">
    <label for="validationTextarea1" style="font-size:15px">Email</label>
    <input class="form-control is-invalid" v-model="formLog.email " id="validationTextarea1" style="font-size:15px"  required>
    
  </div>

  <div class="mb-4">
    <label for="validationTextarea2" style="font-size:15px">Password</label>
    <input class="form-control is-invalid" v-model="formLog.password" type="password" id="validationTextarea2"  style="font-size:15px"  required>
    
  </div>

  

 <div class="text-center">
<button type="submit" class="btn btn-lg btn-warning" style="color:white;font-size:25px;"><strong> Войти</strong></button>
  </div>

</form>

  <div class="text-center mt-3 ">
    <router-link to="/register"><span  class="curs sort mr-4  " style="font-size:15px"><strong class="">Регистрация</strong></span></router-link>
    <router-link to="/forgotpassword"><span  class="curs sort   " style="font-size:15px"><strong class=""> Забыли пароль?</strong></span></router-link>
  </div>

 </div>
</div>
               
               
            </div>
            
      

</div>
</transition>
</template>

<script>


export default {
  data(){
    return{
      formLog:{
        email:null,
        password:null
      }
    }
  },
  methods:{
    Login(){
      const data={
          'email': this.formLog.email,
          'password': this.formLog.password};
            this.$store.dispatch("Login", data)
    }
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
.login{
  display: block;
  width: 400px;
  height: 500px;
}
.forma{
   width: 100%;
  height: 320px; 
}
</style>