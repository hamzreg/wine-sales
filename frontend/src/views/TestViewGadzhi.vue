<template>
  <HomeBackground>
      <SaleList>
      </SaleList>
  </HomeBackground>
</template>


<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/background/HomeBackground.vue"
import InputLine from "@/components/InputLine.vue"
import SaleList from '@/components/sales/SaleList.vue'

export default defineComponent({
setup() {
  // auth.logout()
},
components: {
  HomeBackground,
  SaleList
},
});
</script>


<style scoped>
.logo {
position: absolute;
left: 35%;
bottom: 0%;
}
</style>