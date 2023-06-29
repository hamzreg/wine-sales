<template>
  <div class="container-wine-List">
    <img src="@/assets/img/wineBottle1.png" width="300"/>
    <Text font-size="var(--little-text)" color="var(--green-color)" >
      Сладкие вина красного цвета подают со сладкими десертами, выпечкой и фруктами. Такие вина не подойдут к пряным и копченым блюдам. Белые сладкие вина рекомендуют с фруктами, сырами, десертами, выпечкой и легкими салатами. К таким винам не подойдут острые, пряные, кислые блюда и орехи.
    </Text>

    <img src="@/assets/img/wineBottle2.png" width="300"/>
    <Text font-size="var(--little-text)" color="var(--green-color)">
      Полусладкие вина красного цвета подчеркивают вкус различных десертов, фруктов и выпечки. Такие вина не сочетаются с морепродуктами, соленьями и орехами.  Белые полусладкие вина оттеняют вкус сладких десертов, фруктов, легких салатов и выпечки. Стоит избегать сочетаний таких вин с цитрусами, кислыми блюдами и мятой.
    </Text>

    <img src="@/assets/img/wineBottle3.png" width="300"/>
    <Text font-size="var(--little-text)" color="var(--green-color)">
      Полусухие красного цвета подходят к мясу, овощным блюдам, твердым и молодым сырам. Неподходящей закуской к таким винам считается вяленая рыба, тяжелые жирные блюда и сухофрукты. Белые сухие вина подходят к морепродуктам, птице, салатам и различным видам сыров. Не подходят к таким винам жирная рыба, соленья и слишком пряные блюда.
    </Text>

    <img src="@/assets/img/wineBottle4.png" width="300"/>
    <Text font-size="var(--little-text)" color="var(--green-color)">
      Сухие вина красного цвета хорошо сочетаются с мясом, птицей и твердым сыром. Такие вина не подходят к мягкому сыру, сладостям и первым блюдам.  Белые сухие вина отлично сочетаются с морепродуктами, сырами, птицей и несладкими десертами. Копченая и жирная рыба к таким винам не подходит.
    </Text>
  </div>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'

export default defineComponent({
  name: "CatalogList",
  components: {
    Text
  },
});
</script>


<style scoped>
.container-wine-List {
  display: grid;
  grid-template-columns: 1fr 3fr;
  flex-direction: column;
  margin-top: 8.5%;
  width: 100%;
  height: 100%;
  justify-content: top;
  align-items: center;
  background-color: var(--beige-color);
  gap: 0;
}
</style>