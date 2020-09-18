<template>
 <transition name="fade">
<div class="loginBody" >
            <div class=" register pl-4 pr-4">
                <div class="row ">
                    <div class="col-12 text-center ">
                 <router-link to="/"><img src="../assets/img/1200px-Логотип_МИЭМ.svg.png" id="miem" style="width:200px" class="  "/></router-link>
                 </div>
                </div>
                
                <div class="mymenu2 forma2 p-4">
                  <div class="text-center">
                      <span  class="curs " style="color:rgb(88,89,91);font-size:30px"><strong>Сброс пароля</strong></span>
                  </div>

<div style="position:relative">

  <form class="was-validated" @submit.prevent="SendForm" style="font-size:15px">
  <div class="mb-3">
    <label for="validationTextarea4" style="font-size:15px">Email</label>
    <input type="email" class="form-control is-invalid" v-model="formLog.email" id="validationTextarea4" style="font-size:15px" placeholder="example@edu.hse.ru" required>
    
  </div>

  <div class="custom-control custom-checkbox mb-3">
    <input type="checkbox" class="custom-control-input" id="customControlValidation1" required>
    <label class="custom-control-label" for="customControlValidation1">Я не робот</label>
  </div>

   <div class="mb-3">
       <hr>
      <span  class="curs " style="color:rgb(88,89,91);font-size:15px"><strong>После отправления вам на почту придет форма для восстановления пароля</strong></span>
      <hr>
  </div>


 <div class="text-center">
<button type="submit" class="btn btn-lg btn-warning" style="color:white;font-size:25px;"><strong> Отправить</strong></button>
  </div>
  <div class="text-center mt-3">
<router-link to="/register"><span  class="curs sort mr-4  " style="font-size:15px"><strong class="">Регистрация</strong></span></router-link>     
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


// import swal from 'sweetalert'
export default {
  data(){
    return{
      formLog:{
        email:"",
      },
      AllAboutToken:null
    }
  },
  methods:{
     SendForm(){       
            const data={
                "email": this.formLog.email,
                };  
                  this.$store.dispatch('SendForm',data)
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
  height: 350px; 
}
</style>