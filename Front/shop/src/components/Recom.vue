
<template>
 <hooper   :itemsToShow="3" :wheelControl="false"      id="hooper2" >
    



  <slide v-for="(recom,indx) in recoms" :key="indx" :index="indx" class="m-2 slide  " style="position:relative;">
      <div  class="mymenu2  pt-2 pl-4 h-100 w-100" style="position:absolute;color:rgb(88,89,91)">
          <router-link  :to="'/item/'+recom.id"><span @click="$emit('start')" class="curs " style="color:rgb(88,89,91);font-size:20px"><strong>{{recom.name}}</strong></span></router-link>
          <div class=" row w-100 h-100">
              <div class="col-8">
            <img :src="require('../assets/img/'+ recom.img)" style="width:100%;border-radius:10px" alt="">
              </div>
              <div class="col-4 pr-1 pl-0  ">
                     <span class="d-block mb-5 ml-0"  style="color:rgb(88,89,91);font-size:25px"><strong>{{recom.cost}} руб</strong></span>
                    <button class="btn btn-lg btn-warning " @click="AddMyItem(recom.id)" style="color:white;font-size:25px;"><strong> Купить</strong></button>
              </div> 
          </div>
      </div>

  </slide>

 </hooper>
</template>

<script>


import {
  Hooper,
  Slide,

  } from 'hooper';


export default {
   props:{
       recoms:Array
   },
    data(){
        return{
            RECOMS:[]
        }
    },
    name: 'mini3',
    components: {
    Hooper,
    Slide,
  },
  mounted(){
      this.RECOMS = this.$store.state.recoms
  },
  methods:{
      GetRecoms(){
          return this.$store.state.recoms
      },
       AddMyItem(id){
      this.$store.dispatch('AddMyItem',id)
       //this.$store.dispatch('AddMyItem',id)

    },
  },
 


}
</script>