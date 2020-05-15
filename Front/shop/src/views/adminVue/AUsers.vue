<template>
<div  style='overflow-x:hidden;margin-left: 0px;'>
  <div  class="mt-0   page-main   "> 

<header  class="m-0 p-0">
  <div  id="header" class="">
    <div class="container-lg pt-1 pb-2 pl-4 ">
      <div class="row">
       <div class="col-8">
    <router-link to="/admin"> <span style="font-size:17px;color:white">Администрирование </span></router-link>
       </div>
         <div class="col-4 text-right ">
           <router-link to="/"><img :src="require('@/assets/img/выйти.png')" style="width:25px"   class=" mr-1 pt-1 "/><span style="font-size:17px;" class="link">Выйти</span> </router-link>
       </div>
      </div>  
    </div>
  </div>    
    </header>




    <div class="container-lg mt-lg-5 mt-4 adminka  "  >
      <div class="row">

        <div class=" col-12">
          <div class="mymenu3 p-3 mb-4">
            <div class="row">
          <div class="col-7 text-left pr-0"> 
            <span><strong>Пользователи</strong></span>
          </div>
          <div class="col-5 pl- text-right">
            
            </div>
          </div>
          </div>
        </div>

        <div class="col-12">

            <div class="mymenu3 p-3 mb-2 d-md-block d-none">
              <div class="row">
                  <div class="col-md-3 col-5  pr-0 text-left">
                    <span> <strong>Имя  </strong> </span>
                  </div>
                  
                  <div class="col-md-3 col-6 ">
                    <span> <strong>Email </strong> </span>
                  </div>
                   <div class="col-md-2 col-6 ">
                    <span> <strong>Статус</strong> </span>
                  </div>
                  <div class="col-md-2 col-6 ">
                    <span> <strong>Статус email</strong> </span>
                  </div>
                  <div class="col-md-2 text-right">
                     <span><strong>Действия</strong></span>
                  </div>
              </div>
            </div>


            <div v-for="(user,i) in this.$store.state.users" :key="i" class="mymenu3 p-3 mb-2 ">
              <div class="row">
                  <div class="col-md-3 col-12 pr-0 text-left">
                    <span class="d-md-none d-inline-block"><strong>ФИО: </strong> </span>
                    <router-link :to="'/admin/users/'+user.id"><span> {{user.name}} </span> </router-link> 
                  </div>
                  <div class="col-md-3 col-12 ">
                    <span class="d-md-none d-inline-block"><strong>Email:  </strong> </span>
                    <span> {{user.email}} </span>
                  </div>
                  <div class="col-md-2 col-12 ">
                     <span class="d-md-none d-inline-block"><strong>Статус:   </strong> </span>
                    <span>{{user.isAdmin==true?'admin':'user'}}</span>
                  </div>
                   <div class="col-md-2 col-12 ">
                     <span class="d-md-none d-inline-block"><strong>Статус Email: </strong> </span>
                    <span> {{user.emailConfirmed==true?'подтвержден':'не подтвержден'}}</span>
                  </div>
                  <div v-if="!user.isAdmin" class="col-md-2 col-12 text-right   ">
                       <button type="button" @click="DeleteUser(user.id)" class="btn btn-light btn-sm mybtn  ml-3 " style="font-size:15px" >	&#10006;</button>
                    
                  </div>
                  
              </div>
              
            </div>


        </div>





      </div>
         

    </div>
 
  
    


  </div>  

  </div>  
</template>


<script>

import swal from 'sweetalert'


		

export default {
  name: "Main",
  components: {
  
  },
  data(){
    return{
    

    }
  },
  async mounted(){

        if(this.$store.state.AllAboutToken && this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'){
        console.log("go")
        await this.$store.dispatch('GetUsers')
        }
        else{
            this.$router.push('/')
        }
    
  },
  methods:{
    DeleteUser(id){
         swal({
  title: "Вы действительно хотите удалить пользователя?",
  text: "После удаления товара удалиться все что с ним связано:коментарии,отзывы, покупки",
  icon: "warning",
  buttons: true,
  dangerMode: true,
})
.then((willDelete) => {
  if (willDelete) {
     this.$store.dispatch("DeleteUser",id)
    swal("Пользователь был успешно удален", {
      icon: "success",
    });
    
  } else {
    swal("Вы сохранили ему жизнь!");
  }
});  
    }
    
}
  
}
</script>
