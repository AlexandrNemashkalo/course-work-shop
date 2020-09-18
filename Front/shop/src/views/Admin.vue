<template>
<div  style='overflow-x:hidden;margin-left: 0px;'>
  <div  class="mt-0   page-main   "> 

<header  class="m-0 p-0">
  <div  id="header" class="">
    <div class="container-lg pt-1 pb-2 pl-4 ">
      <div class="row">
       <div class="col-8">
    <span style="font-size:17px;color:white">Администрирование </span>
       </div>
         <div class="col-4 text-right ">
           <router-link to="/"><img src="../assets/img/выйти.png" style="width:25px"   class=" mr-1 pt-1 "/><span style="font-size:17px;" class="link">Выйти</span> </router-link>
       </div>
      </div>  
    </div>
  </div>    
    </header>




    <div class="container-lg mt-lg-5 mt-4  " style="font-size:20px" >
      <div class="row">
        <div class="col-lg-8 col-12">
          <div class="mymenu3 p-3 mb-4">
          <div> <router-link to="/admin/users"><span>Пользователи</span></router-link> </div>
         
          </div>

           <div class="mymenu3 p-3 mb-4">
          <div> <router-link to="/admin/items"><span>Товары</span></router-link> </div>
          <hr>
          <div> <router-link to="/admin/categories"><span>Категории</span></router-link> </div>
          </div>

             <div class="mymenu3 p-3 mb-4">
          <div> <router-link to="/admin/orders"><span>Заказы</span></router-link> </div>
          </div>

            <div class="mymenu3 p-3 mb-4">
          <div> <router-link to="/admin/news"><span>Новости</span></router-link> </div>
        <hr>
           
          <div> <router-link to="/admin/events"><span>События</span></router-link> </div>
          </div>

            <div class="mymenu3 p-3 mb-4">
          <div> <router-link to="/admin/comments"><span>Коментарии</span></router-link> </div>
          <hr>
          <div> <router-link to="/admin/ratings"><span>Отзывы</span></router-link> </div>
          </div>

        </div>
        <div class="col-lg-4 col-12 h-100">
           
        </div>




      </div>
         

    </div>
 
  
    


  </div>  

  </div>  
</template>


<script>

//import swal from 'sweetalert'


		

export default {
  name: "Main",
  components: {
  
  },
  data(){
    return{
    

    }
  },
  mounted(){

        if(this.$store.state.AllAboutToken && this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'){
        console.log("go")
        }
        else{
            this.$router.push('/')
        }
    
  },
  methods:{
    
}
  
}
</script>















