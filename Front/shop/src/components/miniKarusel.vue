<template>
  <hooper :autoPlay="false" id="hooper"  :infiniteScroll="true" :wheelControl="false" :centerMode="true" >
    <slide style="">
      <img src="../assets/img/Таллинсклнраздачи.jpg" class="h-100 "  alt="">
    </slide>
    <slide>
       <img src="../assets/img/Таллинскфотозала.jpg" class="h-100 "  alt="">
    </slide>
     <slide >
      <div class=" " >

      </div>
     <iframe  id='fp_embed_player' src='https://demo.flashphoner.com:8888/embed_player?urlServer=wss://demo.flashphoner.com:8443&streamName=rtsp://admin:9801dkfl@178.165.53.63:554/cam/realmonitor?channel=1%26subtype=0%26unicast=true%26proto=Onvif&mediaProviders=WebRTC,Flash,MSE,WSPlayer&autoplay=false'
          marginwidth='0'
          marginheight='0'
          frameborder='0' 
          width='100%' 
          height='100%' 
          scrolling='no' 
          allowfullscreen='allowfullscreen'
        ></iframe>
    </slide>

     <hooper-pagination  slot="hooper-addons"></hooper-pagination>
   <hooper-navigation2 class="d-md-block d-none" slot="hooper-addons"></hooper-navigation2>
  </hooper>
</template>

<script>
import { Hooper, Slide, Pagination  as HooperPagination,
  Navigation as HooperNavigation2} from 'hooper';
import 'hooper/dist/hooper.css';

export default {
  name: 'mini',
  components: {
    Hooper,
    Slide,
   HooperPagination,
    HooperNavigation2
  }
};
</script>
