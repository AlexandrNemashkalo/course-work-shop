<template>
    <div class="container ml-0">
	<div class="row">
	<div :class="'rating rating/'+this.item.id">
   
      <input @click="Star(10)"  type="radio" :id="'star/10/'+this.item.id" :name="'rating/'+this.item.id" value="10" /><label :for="'star/10/'+this.item.id" >5 stars</label>
      <input @click="Star(9)" type="radio" :id="'star/9/'+this.item.id" :name="'rating/'+this.item.id"   value="9" /><label :for="'star/9/'+this.item.id" >4 stars</label>
      <input @click="Star(8)" type="radio" :id="'star/8/'+this.item.id" :name="'rating/'+this.item.id"  value="8"  /><label :for="'star/8/'+this.item.id" >3 stars</label>
      <input @click="Star(7)" type="radio" :id="'star/7/'+this.item.id" :name="'rating/'+this.item.id" value="7" /><label :for="'star/7/'+this.item.id" >2 stars</label>
      <input @click="Star(6)" type="radio" :id="'star/6/'+this.item.id" :name="'rating/'+this.item.id"  value="6"  /><label :for="'star/6/'+this.item.id" >1 star</label>
      <input @click="Star(5)" type="radio" :id="'star/5/'+this.item.id" :name="'rating/'+this.item.id"  value="5" /><label :for="'star/5/'+this.item.id" >5 stars</label>
      <input @click="Star(4)" type="radio" :id="'star/4/'+this.item.id" :name="'rating/'+this.item.id"   value="4" /><label :for="'star/4/'+this.item.id" >4 stars</label>
      <input @click="Star(3)" type="radio" :id="'star/3/'+this.item.id" :name="'rating/'+this.item.id" value="3" /><label :for="'star/3/'+this.item.id" >3 stars</label>
      <input @click="Star(2)" type="radio" :id="'star/2/'+this.item.id" :name="'rating/'+this.item.id"  value="2"  /><label :for="'star/2/'+this.item.id">2 stars</label>
      <input @click="Star(1)" type="radio" :id="'star/1/'+this.item.id" :name="'rating/'+this.item.id"   value="1" /><label :for="'star/1/'+this.item.id">1 star</label>
    </div>
    {{this.item.kStars}}
    </div>
    
	</div>
</template>
<script>
import swal from 'sweetalert'
export default {
    props:{
        item:Object

    },
    data(){
        return{
            flag: false
        }
    },
    mounted(){
        this.Start()
        

    },
    methods:{
    async Star(n){
        if(this.flag == true){
            if(this.$store.state.AllAboutToken == null){
      swal({
      text: "Вам нужно авторизоваться",
      icon: "warning",
      });
      }
      else{
            this.item.top = n
            await this.$store.dispatch('AddRating',this.item)
            
      }
        }
    },
    Start(){

        if(this.item.kStars>0){

        var r =document.getElementById('star/'+Math.round(this.item.stars/this.item.kStars)+'/' + this.item.id)
        r.click()
 
        }
        this.flag =true
    }
    }
}
</script>
<style scoped>



</style>
