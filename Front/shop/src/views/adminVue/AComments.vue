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
            <span><strong>Коментарии</strong></span>
          </div>
          <div class="col-5 pl- text-right">
            
            </div>
          </div>
          </div>
        </div>

        <div class="col-12">

          <div v-for="comment in this.$store.state.allComments" :key ="comment.id">
            <div> <button type="button" @click="DeleteComment(comment.id)"  class="btn btn-light btn-sm mybtn  ml-3 " style="font-size:15px;position:absolute;right:15px" >	&#10006;</button></div>
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:25px"><strong>{{comment.userName}}</strong> </span>
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:20px">{{comment.text}}</span>
                    <span  class=" d-block font-weight-light " style="color:rgb(88,89,91);font-size:15px">{{GetDate(comment.date)}}</span>
                      <span  class=" d-block font-weight-light " style="color:rgb(88,89,91);font-size:15px">{{comment.itemName}}</span>
                      
                    <hr>

                     <button class="ma-2" @click="AddLike(comment.id , true)" style="position:absolute;bottom:20px;right:60px;border:none; background-color:#f6f6f6">

        <img src="@/assets/img/лайк.jpeg" style="width:25px" class="pr-1">
        <span style="font-size:15px">{{comment.kLikes}}</span>
      </button >

      <button @click="AddLike(comment.id , false)" style="position:absolute;bottom:20px;right:5px;border:none; background-color:#f6f6f6">
        <img src="@/assets/img/дизлайк.jpeg" style="width:25px" class="pr-1">
             <span style="font-size:15px">{{comment.kDisLikes}}</span>
      </button>
      

                </div>
              

        </div>
      </div>
    </div>
  </div>  

  </div>  
</template>


<script>

//import swal from 'sweetalert'
import moment from 'moment'

		

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
        await this.$store.dispatch('GetComments')
        }
        else{
            this.$router.push('/')
        }
    
  },
  methods:{
      /*GetNameCategory(id){
        return  this.$store.state.categories.find(e => e.id == id).name

      }*/
      GetDate(date){
        return moment(date).format("LLL")
      },
      async AddLike(id,type){
       
      var form = {
        id:id,
        type:type
      }
       await this.$store.dispatch("AddLike",form)
       await this.$store.dispatch('GetComments')
       
        
    },
     async  DeleteComment(id){ 
    await this.$store.dispatch("DeleteComment",id)
    await this.$store.dispatch('GetComments')
   
     }
    
}
  
}
</script>
