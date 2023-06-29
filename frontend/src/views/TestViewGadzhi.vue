<template>
  <HomeBackground>
      <CatalogList>
      </CatalogList>
  </HomeBackground>
</template>


<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/background/HomeBackground.vue"
import InputLine from "@/components/InputLine.vue"
import CatalogList from '@/components/catalog/CatalogList.vue'

export default defineComponent({
setup() {
  // auth.logout()
},
components: {
  HomeBackground,
  CatalogList
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