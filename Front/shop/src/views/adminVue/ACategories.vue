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
            <span><strong>Категории</strong></span>
          </div>
          <div class="col-5 pl- text-right">
              <button v-if="!showAdd" type="button" @click="showAdd=true" class="btn btn-success">Добавить</button>
            </div>
          </div>
          </div>
        </div>

        <div class="col-12">





            <div class="mymenu3 p-3 mb-2 d-md-block d-none">
              <div class="row">
                  <div class="col-md-2 col-5  pr-0 text-left">
                    <span> <strong>Название  </strong> </span>
                  </div>
                  
                   <div class="col-md-2 col-6 pl-0">
                    <span> <strong>Изображение</strong> </span>
                  </div>
                    
              </div>
            </div>


             <div v-if="showAdd"  class="mymenu3   m-0 w-100 mt-lg-4 mb-3 p-3 product-item " style="position:relative;" >
 <button type="button" @click="showAdd=false" style="position:absolute;bottom:4px;right:5px;z-index:6" class="btn btn-warning">&#10006;</button>
            <form action="" @submit.prevent="AddCategory" class="w-100 pl-3  row ">
           <div class="col-md-2  pl-0">
             <div>
               <b-form-input  v-model="addItem.name" style="font-size:15px" required ></b-form-input>
               </div>
           </div>
           <div class="col-md-2 pl-0">
            <span class="d-md-none d-inline-block"> <strong>Изображение:</strong> </span>
              <b-form-file  style="overflow:hidden"
              v-model="addItem.file"
            ></b-form-file>
           </div>
              <button type="submit" style="position:absolute;bottom:31px;right:5px;z-index:6" class="btn btn-success">&#10010;</button>
          
           </form>
           
        </div>









 <div v-for="category in this.$store.state.categories" :key="category.id" style="position:relative;overflow: visible">

        <div   class="mymenu2  row m-0 w-100 mt-lg-4 mb-3 p-3 product-item " >
          <div v-if="Edit(category.id)" class="p-0" style="font-size:20px;position:absolute;right:-5px;top:0px; ">
        <b-dropdown size="lg"  class="p-0"   variant="link" toggle-class="text-decoration-none" no-caret>
          <template v-slot:button-content style="color:black;font-size:20px;z-index:5">
            <span style="color:black;font-size:20px;z-index:5"  >⋮</span>
          </template>
          <div style="z-index:6;font-size:12px" >
          <b-dropdown-item  @click="Delete(category.id)" style="z-index:10;font-size:12px" href="#">Удалить</b-dropdown-item>
          <b-dropdown-item  style="z-index:10;font-size:12px" @click="editId= category.id" href="#">Изменить</b-dropdown-item>
          </div>
        </b-dropdown>
      </div>

      <div v-if="!Edit(category.id)" style="font-size:20px;position:absolute;right:5px;top:5px;z-index:100 ">
          <button class="p-0 btn btn-light" @click="SaveEdit(category)" style="font-size:15px;z-index:100">	&#128190;</button>
      </div>


           <div class="col-md-2 pl-0">
               <b-form-input v-if="!Edit(category.id)" v-model="category.name" style="font-size:15px" required ></b-form-input>
                <span v-if="Edit(category.id)" class="text-right">   {{category.name}}</span>
 
           </div>

           <div class="col-md-2 pl-0">
            <span class="d-md-none d-inline-block"> <strong>Изображение:</strong> </span>
              <b-form-file v-if="!Edit(category.id)" style="overflow:hidden"
              v-model="file"
              :placeholder="category.img"
            ></b-form-file>
            <span v-if="Edit(category.id)" class="text-right"> {{category.img}}</span>
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
     editId:"",
      
        file: null,
        status: 'not_accepted',
        addItem:{
          name:null,
          img:null,
          file:null
        },
        showAdd: false

    }
  },
  async mounted(){

        if(this.$store.state.AllAboutToken && this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'){
        console.log("go")
        await this.$store.dispatch('GetCategories')
        }
        else{
            this.$router.push('/')
        }
    
  },
  methods:{
    Delete(id){
       swal({
  title: "Вы действительно хотите удалить категорию?",
  text: "После удаления категории удалятся все товары, принадлежашие данной категории",
  icon: "warning",
  buttons: true,
  dangerMode: true,
})
.then((willDelete) => {
  if (willDelete) {
     this.$store.dispatch("DeleteCategory",id)
    swal("Категория была успешно удалена", {
      icon: "success",
    });
    
  } else {
    swal("Вы сохранили ему жизнь!");
  }
});  
    },
    Edit(id){
        return this.editId == id? false :true
      },
      SaveEdit(item){
        console.log(item)
        console.log(this.file)
        item.img = this.file==null? item.img: this.file.name
        this.$store.dispatch("EditCategory",item)
        this.editId = ""
        this.file = null
      },
      AddCategory(){
       this.addItem.img = this.addItem.file.name
        this.$store.dispatch("AddCategory",this.addItem)
        console.log(this.addItem)
        this.showAdd =false
      }
     
    
}
  
}
</script>
