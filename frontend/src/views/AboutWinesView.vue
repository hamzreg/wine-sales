<template>
  <Background>
    <NavBarView>
      <WineList/>
    </NavBarView>
  </Background>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Background from '@/components/background/Background.vue'
import NavBarView from './NavBarView.vue'
import WineList from '@/components/wine/WineList.vue'
    
export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background,
    NavBarView,
    WineList
  },
})
</script>


<style scoped>
</style>