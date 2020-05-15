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
            <span><strong>Отзывы</strong></span>
          </div>
          <div class="col-5 pl- text-right">
            
            </div>
          </div>
          </div>
        </div>

        <div class="col-12">

       <div v-for="rating in ratings" :key ="rating.id">
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:25px"><strong>{{rating.itemName}}</strong></span>
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:20px">{{rating.star}} звезд</span>
                    <span  class=" d-block font-weight-light " style="color:rgb(88,89,91);font-size:15px">{{GetDate(rating.date)}}</span>
                    <hr>
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
import axios from 'axios'
import { Sort} from "@/store/func"
		

export default {
  name: "Main",
  components: {
  
  },
  data(){
    return{
    ratings:[]

    }
  },
  async mounted(){

        if(this.$store.state.AllAboutToken && this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'){
        console.log("go")
        await this.GetRatings()
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
       async GetRatings(){
             var config ={headers:{ Authorization :"Bearer "+ this.$store.state.AllAboutToken.accessToken}}
      await axios.get('http://localhost:5000/api/rating/',config).then(response => {
      this.ratings = Sort(response.data)
  }).catch(function (error) {console.log(error)});
    },
    
}
  
}
</script>
