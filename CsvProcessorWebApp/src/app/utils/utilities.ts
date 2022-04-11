export function parsearErroresAPI(response: any): string[] {

  const resultado: string[] = [];
  console.log(response.status);

  if (response.status === 500){
    resultado.push('Ha ocurrido un error en el servidor. Favor intentar más tarde');
    return resultado;
  }

  if (response.error) {
    if (typeof response.error === 'string') {
      resultado.push(response.error);
    } else {
      const mapaErrores = response.error.errors;
      const entradas = Object.entries(mapaErrores);
      entradas.forEach((arreglo: any[]) => {
        const campo = arreglo[0];
        arreglo[1].forEach((mensajeError: any) => {
          resultado.push(`${campo}: ${mensajeError}`);
        });
      });
    }
  }

  return resultado;
}
