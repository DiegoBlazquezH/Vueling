$ErrorActionPreference = 'Stop'

if (Test-Path 'env:VariableTesting') { 
    'La variable VariableTesting ya existe' 
} else {
    'Creando variable de entorno'
    [Environment]::SetEnvironmentVariable('VariableTesting', 'Valor de prueba', 'User')
    'Variable de entorno creada'
}

# Read-Host 'Pulsa Enter para continuar' | Out-Null