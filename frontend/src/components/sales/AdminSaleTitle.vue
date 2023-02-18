<template>
  <div class="sale-title">
		<Text font-size="var(--little-text)" color="var(--wine-color)">
			Вино
		</Text>
		<Text font-size="var(--little-text)" color="var(--wine-color)">
			Закупочная цена (₽)
		</Text>
		<Text font-size="var(--little-text)" color="var(--wine-color)">
			Цена реализации (₽)
		</Text>
		<Text font-size="var(--little-text)" color="var(--wine-color)">
			Количество (шт)
		</Text>
		<Text font-size="var(--little-text)" color="var(--wine-color)">
			Дата
		</Text>
		<Text font-size="var(--little-text)" color="var(--wine-color)">
			Прибыль (₽)
		</Text>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'
    
export default defineComponent({
  name: "AdminSaleTitle",
  components: {
    Text
  }
})
</script>
  
  
<style scoped>
.sale-title {
  display: grid;
  grid-template-columns: 2fr 2fr 2fr 2fr 2fr 2fr;
  column-gap: 50px;
  width: 100%;
}
</style>