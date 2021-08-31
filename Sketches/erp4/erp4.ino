#include <Wire.h>
#include "pcf8574.h"
#include "pcf8574A.h"
bool testPrint = false;
bool notKPAPrint = false;
bool PrintZ = false;
bool PrintUNITY = true;
unsigned long t = 0;
int i;
int n = 0;
#include <ACE128.h>
#include <ACE128map87654321.h> // Карта пинов 87654321
String arduinoSymbol = "f"; // Обозначение платы
String arduinoSlaveGsymbol = "g"; // Обозначение платы G
String endSymbol = "z"; // Обозначение конца сообщения
String potSymbol = "p"; // Обозначение потенциометров
//        ПЕРЕМЕННЫЕ ЭЛЕМЕНТОВ НА PCF A  //////////////////////////////////////////////////////////////////////
// определяем адресса pcf для отжимных кнопок
#define PCF_A_ADDRESS 0x20 // Адрес PCF A
// объявляем переменную для библиотеки и указанием индекса
pcf8574 pcfA(PCF_A_ADDRESS); // Определение PCF A
// сколько добавить кнопок перед 
int pcfAADDints = 0;
// Обозначение элементов на PCF A
String pcfAelemSymbol = "a"; 
// Количество элементов на PCF A
#define PCF_A_ELEM_NUM 8 
// Пины элементов на PCF A
const byte pcfAelemPin[PCF_A_ELEM_NUM] = {0, 1, 2, 3, 7, 6, 5, 4}; 
// подмен пинов для pcf
const byte pcfAelemPin2[PCF_A_ELEM_NUM] = {3, 2, 1, 0, 7, 6, 5, 4}; 
boolean pcfAelemPos[PCF_A_ELEM_NUM] = {false, false, false, false, false, false, false, false}; // Положение
boolean pcfAelemRev[PCF_A_ELEM_NUM] = {false, false, false, false, false, false, false, false}; // Реверс
//дополнительное принуждение к опросу
boolean pcfAelemADD[PCF_A_ELEM_NUM] = {false, false, false, false, false, false, false, false}; 
unsigned int pcfAelemDelay[PCF_A_ELEM_NUM] = {100, 100, 100, 100, 100, 100, 100, 100};
// Время между двумя изменениями положения
unsigned long pcfAelemTime[PCF_A_ELEM_NUM] = {0, 0, 0, 0, 0, 0, 0, 0};
// Время между двумя  принудительными изменениями положения
unsigned long pcfAelemTimeADD[PCF_A_ELEM_NUM] = {0, 0, 0, 0, 0, 0, 0, 0};
// Момент времени изменения положения
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        ПЕРЕМЕННЫЕ ЭЛЕМЕНТОВ НА PCF B  //////////////////////////////////////////////////////////////////////
// определяем адресса pcf для отжимных кнопок
#define PCF_B_ADDRESS 0x21 // Адрес PCF B
// объявляем переменную для библиотеки и указанием индекса
pcf8574 pcfB(PCF_B_ADDRESS); // Определение PCF B
// сколько добавить кнопок перед 
int pcfBADDints = 8;
// Обозначение элементов на PCF B
String pcfBelemSymbol = "b"; 
// Количество элементов на PCF B
#define PCF_B_ELEM_NUM 2 
// Пины элементов на PCF A
const byte pcfBelemPin[PCF_B_ELEM_NUM] = {0, 1}; 
// подмен пинов для pcf
const byte pcfBelemPin2[PCF_B_ELEM_NUM] = {3, 2}; 
boolean pcfBelemPos[PCF_B_ELEM_NUM] = {false, false}; // Положение
boolean pcfBelemRev[PCF_B_ELEM_NUM] = {false, false}; // Реверс
//дополнительное принуждение к опросу
boolean pcfBelemADD[PCF_B_ELEM_NUM] = {false, false}; 
unsigned int pcfBelemDelay[PCF_B_ELEM_NUM] = {100, 100};
// Время между двумя изменениями положения
unsigned long pcfBelemTime[PCF_B_ELEM_NUM] = {0, 0};
// Время между двумя  принудительными изменениями положения
unsigned long pcfBelemTimeADD[PCF_B_ELEM_NUM] = {0, 0};
// Момент времени изменения положения
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        ПЕРЕМЕННЫЕ ЭЛЕМЕНТОВ НА PCF C  //////////////////////////////////////////////////////////////////////
// определяем адресса pcf для отжимных кнопок
#define PCF_C_ADDRESS 0x22 // Адрес PCF C
// объявляем переменную для библиотеки и указанием индекса
pcf8574 pcfC(PCF_C_ADDRESS); // Определение PCF C
// сколько добавить кнопок перед 
int pcfCADDints = 10;
// Обозначение элементов на PCF C
String pcfCelemSymbol = "c"; 
// Количество элементов на PCF C
#define PCF_C_ELEM_NUM 8 
// Пины элементов на PCF C
const byte pcfCelemPin[PCF_C_ELEM_NUM] = {0, 1, 2, 3, 7, 6, 5, 4}; 
// подмен пинов для pcf
const byte pcfCelemPin2[PCF_C_ELEM_NUM] = {3, 2, 1, 0, 7, 6, 5, 4}; 
boolean pcfCelemPos[PCF_C_ELEM_NUM] = {false, false, false, false, false, false, false, false}; // Положение
boolean pcfCelemRev[PCF_C_ELEM_NUM] = {false, false, false, false, false, false, false, false}; // Реверс
//дополнительное принуждение к опросу
boolean pcfCelemADD[PCF_C_ELEM_NUM] = {false, false, false, false, false, false, false, false}; 
unsigned int pcfCelemDelay[PCF_C_ELEM_NUM] = {20, 20, 20, 20, 20, 20, 20, 20};
// Время между двумя изменениями положения
unsigned long pcfCelemTime[PCF_C_ELEM_NUM] = {0, 0, 0, 0, 0, 0, 0, 0};
// Время между двумя  принудительными изменениями положения
unsigned long pcfCelemTimeADD[PCF_C_ELEM_NUM] = {0, 0, 0, 0, 0, 0, 0, 0};
// Момент времени изменения положения
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        ПЕРЕМЕННЫЕ ЭЛЕМЕНТОВ НА PCF D  //////////////////////////////////////////////////////////////////////
// определяем адресса pcf для отжимных кнопок
#define PCF_D_ADDRESS 0x23 // Адрес PCF D
// объявляем переменную для библиотеки и указанием индекса
pcf8574 pcfD(PCF_D_ADDRESS); // Определение PCF D
// сколько добавить кнопок перед 
int pcfDADDints = 18;
// Обозначение элементов на PCF D
String pcfDelemSymbol = "d"; 
// Количество элементов на PCF D
#define PCF_D_ELEM_NUM 2 
// Пины элементов на PCF D
const byte pcfDelemPin[PCF_D_ELEM_NUM] = {0, 1}; 
// подмен пинов для pcf
const byte pcfDelemPin2[PCF_D_ELEM_NUM] = {8, 7}; 
boolean pcfDelemPos[PCF_D_ELEM_NUM] = {false, false}; // Положение
boolean pcfDelemRev[PCF_D_ELEM_NUM] = {false, false}; // Реверс
//дополнительное принуждение к опросу
boolean pcfDelemADD[PCF_D_ELEM_NUM] = {false, false}; 
unsigned int pcfDelemDelay[PCF_D_ELEM_NUM] = {20, 20};
// Время между двумя изменениями положения
unsigned long pcfDelemTime[PCF_D_ELEM_NUM] = {0, 0};
// Время между двумя  принудительными изменениями положения
unsigned long pcfDelemTimeADD[PCF_D_ELEM_NUM] = {0, 0};
// Момент времени изменения положения
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        ПЕРЕМЕННЫЕ ЭЛЕМЕНТОВ НА PCF F  //////////////////////////////////////////////////////////////////////
// определяем адресса pcf для отжимных кнопок
#define PCF_F_ADDRESS 0x25 // Адрес PCF F
// объявляем переменную для библиотеки и указанием индекса
pcf8574 pcfF(PCF_F_ADDRESS); // Определение PCF F
// сколько добавить кнопок перед 
int pcfFADDints = 20;
// Обозначение элементов на PCF F
String pcfFelemSymbol = "f"; 
// Количество элементов на PCF F
#define PCF_F_ELEM_NUM 2 
// Пины элементов на PCF F
const byte pcfFelemPin[PCF_F_ELEM_NUM] = {1, 0}; 
// подмен пинов для pcf
const byte pcfFelemPin2[PCF_F_ELEM_NUM] = {4, 5}; 
boolean pcfFelemPos[PCF_F_ELEM_NUM] = {false, false}; // Положение
boolean pcfFelemRev[PCF_F_ELEM_NUM] = {false, false}; // Реверс
//дополнительное принуждение к опросу
boolean pcfFelemADD[PCF_F_ELEM_NUM] = {false, false}; 
unsigned int pcfFelemDelay[PCF_F_ELEM_NUM] = {20, 20};
// Время между двумя изменениями положения
unsigned long pcfFelemTime[PCF_F_ELEM_NUM] = {0, 0};
// Время между двумя  принудительными изменениями положения
unsigned long pcfFelemTimeADD[PCF_F_ELEM_NUM] = {0, 0};
// Момент времени изменения положения
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        ПЕРЕМЕННЫЕ ЭЛЕМЕНТОВ НА PCF G  //////////////////////////////////////////////////////////////////////
// определяем адресса pcf для отжимных кнопок
#define PCF_G_ADDRESS 0x24 // Адрес PCF G
// объявляем переменную для библиотеки и указанием индекса
pcf8574 pcfG(PCF_G_ADDRESS); // Определение PCF G
// сколько добавить кнопок перед 
int pcfGADDints = 22;
// Обозначение элементов на PCF G
String pcfGelemSymbol = "g"; 
// Количество элементов на PCF G
#define PCF_G_ELEM_NUM 8 
// Пины элементов на PCF G
const byte pcfGelemPin[PCF_G_ELEM_NUM] = {4, 5, 6, 7, 3, 2, 1, 0}; 
// подмен пинов для pcf
const byte pcfGelemPin2[PCF_G_ELEM_NUM] = {3, 2, 1, 0, 7, 6, 5, 4}; 
boolean pcfGelemPos[PCF_G_ELEM_NUM] = {false, false, false, false, false, false, false, false}; // Положение
boolean pcfGelemRev[PCF_G_ELEM_NUM] = {false, false, false, false, false, false, false, false}; // Реверс
//дополнительное принуждение к опросу
boolean pcfGelemADD[PCF_G_ELEM_NUM] = {false, false, false, false, false, false, false, false}; 
unsigned int pcfGelemDelay[PCF_G_ELEM_NUM] = {20, 20, 20, 20, 20, 20, 20, 20};
// Время между двумя изменениями положения
unsigned long pcfGelemTime[PCF_G_ELEM_NUM] = {0, 0, 0, 0, 0, 0, 0, 0};
// Время между двумя  принудительными изменениями положения
unsigned long pcfGelemTimeADD[PCF_G_ELEM_NUM] = {0, 0, 0, 0, 0, 0, 0, 0};
// Момент времени изменения положения
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        ПЕРЕМЕННЫЕ ЭЛЕМЕНТОВ НА PCF I  //////////////////////////////////////////////////////////////////////
// определяем адресса pcf для отжимных кнопок
#define PCF_I_ADDRESS 0x27 // Адрес PCF I
// объявляем переменную для библиотеки и указанием индекса
pcf8574 pcfI(PCF_I_ADDRESS); // Определение PCF I
// сколько добавить кнопок перед 
int pcfIADDints = 30;
// Обозначение элементов на PCF I
String pcfIelemSymbol = "a"; 
// Количество элементов на PCF I
#define PCF_I_ELEM_NUM 2 
// Пины элементов на PCF I
const byte pcfIelemPin[PCF_I_ELEM_NUM] = {1, 0}; 
// подмен пинов для pcf
const byte pcfIelemPin2[PCF_I_ELEM_NUM] = {3, 2}; 
boolean pcfIelemPos[PCF_I_ELEM_NUM] = {false, false}; // Положение
boolean pcfIelemRev[PCF_I_ELEM_NUM] = {false, false}; // Реверс
//дополнительное принуждение к опросу
boolean pcfIelemADD[PCF_I_ELEM_NUM] = {false, false}; 
unsigned int pcfIelemDelay[PCF_I_ELEM_NUM] = {20, 20};
// Время между двумя изменениями положения
unsigned long pcfIelemTime[PCF_I_ELEM_NUM] = {0, 0};
// Время между двумя  принудительными изменениями положения
unsigned long pcfIelemTimeADD[PCF_I_ELEM_NUM] = {0, 0};
// Момент времени изменения положения
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        ПЕРЕМЕННЫЕ ЭЛЕМЕНТОВ НА PCF H  //////////////////////////////////////////////////////////////////////
// определяем адресса pcf для отжимных кнопок
#define PCF_H_ADDRESS 0x26 // Адрес PCF H
// объявляем переменную для библиотеки и указанием индекса
pcf8574 pcfH(PCF_H_ADDRESS); // Определение PCF H
// сколько добавить кнопок перед 
int pcfHADDints = 32;
// Обозначение элементов на PCF H
String pcfHelemSymbol = "a"; 
// Количество элементов на PCF H
#define PCF_H_ELEM_NUM 8 
// Пины элементов на PCF H
const byte pcfHelemPin[PCF_H_ELEM_NUM] = {4, 5, 6, 7, 3, 2, 1, 0}; 
// подмен пинов для pcf
const byte pcfHelemPin2[PCF_H_ELEM_NUM] = {3, 2, 1, 0, 7, 6, 5, 4}; 
boolean pcfHelemPos[PCF_H_ELEM_NUM] = {false, false, false, false, false, false, false, false}; // Положение
boolean pcfHelemRev[PCF_H_ELEM_NUM] = {false, false, false, false, false, false, false, false}; // Реверс
//дополнительное принуждение к опросу
boolean pcfHelemADD[PCF_H_ELEM_NUM] = {false, false, false, false, false, false, false, false}; 
unsigned int pcfHelemDelay[PCF_H_ELEM_NUM] = {20, 20, 20, 20, 20, 20, 20, 20};
// Время между двумя изменениями положения
unsigned long pcfHelemTime[PCF_H_ELEM_NUM] = {0, 0, 0, 0, 0, 0, 0, 0};
// Время между двумя  принудительными изменениями положения
unsigned long pcfHelemTimeADD[PCF_H_ELEM_NUM] = {0, 0, 0, 0, 0, 0, 0, 0};
// Момент времени изменения положения
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

///////////////////////Кнопки и тумблеры 2////////////////////////////
////2 позиции////
String  character_A = "b";
// Задержка
#define BUTTDELAY_A 50
// Количество кнопок
#define BUTTNUM_A 11
// количество кнопок перед указанными
int butADD_A = 40;
const byte buttPin_A[BUTTNUM_A] = {32,34,44,46,24,26,28,36,38,40,42};
// Положение кнопки
boolean buttPos_A[BUTTNUM_A] = {false,false,false,false,false,false,false,false,false,false,false};
// Реверс кнопки
boolean buttRev_A[BUTTNUM_A] = {false,false,false,false,false,false,false,false,false,false,false};
// Момент времени изменения положения кнопки
unsigned long buttTime_A[BUTTNUM_A] = {0,0,0,0,0,0,0,0,0,0,0};
// новый вариант строки
bool NEWstring = true;
////////////////////////////////////////////////////////////////////////////
///////////////////////Кнопки и тумблеры 2////////////////////////////
////2 позиции////
String  character_B = "f";
// Задержка
#define BUTTDELAY_B 1000
// Количество кнопок
#define BUTTNUM_B 3
// количество кнопок перед указанными
int butADD_B = 0;
const byte buttPin_B[BUTTNUM_B] = {48,50,52};
// Положение кнопки
boolean buttPos_B[BUTTNUM_B] = {false,false,false};
// Реверс кнопки
boolean buttRev_B[BUTTNUM_B] = {false,false,false};
// Момент времени изменения положения кнопки
unsigned long buttTime_B[BUTTNUM_B] = {0,0,0};

////////////////////////////////////////////////////////////////////////////


///////////////////////Кнопки и тумблеры 2////////////////////////////
////2 позиции////
String  character_C = "c";
// Задержка
#define BUTTDELAY_C 3000
// Количество кнопок
#define BUTTNUM_C 6
// количество кнопок перед указанными
int butADD_C = 0;
const byte buttPin_C[BUTTNUM_C] = {14,15,6,7,8,9};
// Положение кнопки
boolean buttPos_C[BUTTNUM_C] = {false,false,false,false,false,false};
// Реверс кнопки
boolean buttRev_C[BUTTNUM_C] = {false,false,false,false,false,false};
// Момент времени изменения положения кнопки
unsigned long buttTime_C[BUTTNUM_C] = {0,0,0,0,0,0};
// новый вариант строки
////////////////////////////////////////////////////////////////////////////



#include <ACE128.h>
#include <ACE128map87654321.h> // Карта пинов 87654321

String str;


//#define ENCSETUP // Раскомментировать для настройки
//#define ENCODERSETUP

#define ENCNUM 2 // Количество энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
const byte encoderAddress[ENCNUM]= {0x38,0x39}; // Адреса энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
ACE128 enc0((uint8_t)encoderAddress[0], (uint8_t*)encoderMap_87654321);
ACE128 enc1((uint8_t)encoderAddress[1], (uint8_t*)encoderMap_87654321);

bool NEWstring_encoder = true;
uint8_t rawPos[ENCNUM] = {0,0}; // Текущее положение энкодера
uint8_t oldRawPos[ENCNUM] = {127,127}; // Предыдущее положение энкодера

#ifndef ENCSETUP
  int encType[ENCNUM] = {1}; // Тип энкодера !!!  0 - приведение к границам, 1 - границы и круговой, 4 - круговой (0.00 - 1.00)
  int rawBorder[ENCNUM][2] = {{29, 82},{70, 109}};
  // Границы положений энкодера
  int encBorder[ENCNUM][2] = {{0, 5},{0, 8}};
  // Границы положений энкодера по шкале
  
  double encPoint[ENCNUM] = {0,0}; // Средняя точка
  double encPos[ENCNUM] = {0,0}; // Положение энкодера по шкале
  double oldEncPos[ENCNUM] = {0,0}; // Предыдущее положение энкодера по шкале
  double rawNorm[ENCNUM] = {0,0}; // Норма
#endif


///////////////////////////////////////////////////NeoPixelBus befor setup ////////////////////////////////////////
#include <NeoPixelBus.h>

const uint16_t PixelCount = 67; // this example assumes 4 pixels, making it smaller will cause a failure
const uint8_t PixelPin = 13;  // make sure to set this to the correct pin, ignored for Esp8266

#define colorSaturation 128
NeoPixelBus<NeoGrbFeature, Neo800KbpsMethod> strip(PixelCount, PixelPin);
RgbColor red(colorSaturation, 0, 0);
RgbColor green(0, colorSaturation, 0);
RgbColor blue(0, 0, colorSaturation);
RgbColor white(colorSaturation);
RgbColor black(0);
HslColor hslRed(red);
HslColor hslGreen(green);
HslColor hslBlue(blue);
HslColor hslWhite(white);
HslColor hslBlack(black);
///////////////////////////////////////////////////NeoPixelBus befor setup ////////////////////////////////////////

void setup() {
  // put your setup code here, to run once:
 Serial.begin(115200);  // Инициализация порта для работы
Serial.println("ERP4");
Serial.println("complite");
///////////////////////////////////////////////////NeoPixelBus setup ////////////////////////////////////////
    strip.Begin();
    strip.Show();
///////////////////////////////////////////////////NeoPixelBus setup ////////////////////////////////////////


//        НАСТРОЙКИ КНОПОК                                                       //
  ////                                                                            ////
  for (i = 0; i < BUTTNUM_C; i++) {
    pinMode(buttPin_C[i], INPUT); // Настройка пина на вход
    digitalWrite(buttPin_C[i], HIGH); // Подтяжка пина к питанию
  }
  for (i = 0; i < BUTTNUM_C; i++) { // Опрос кнопок
    if (buttRev_C[i] == false) {
      if (digitalRead(buttPin_C[i]) == HIGH) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_C);
        Serial.print(" off");
        Serial.println("z");
        }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
      }
      else if (digitalRead(buttPin_C[i]) == LOW) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_C);
        Serial.print(" on");
        Serial.println("z");
        buttPos_C[i] = true;
         }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
        buttPos_C[i] = true;
          }
      }
    }
    else {
      if (digitalRead(buttPin_C[i]) == HIGH) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_C);
        Serial.print(" on");
        Serial.println("z");
        buttPos_C[i] = true;
         }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
        buttPos_C[i] = true;
          }
      }
      else if (digitalRead(buttPin_C[i]) == LOW) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_C);
        Serial.print(" off");
        Serial.println("z");
         }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
      }
    }
    n++;
  }


  #ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED");
  #endif
  
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  enc0.begin();
  enc1.begin();

 
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos();
  rawPos[1] = enc1.rawPos();

  
  #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод текущего положения энкодера
      oldRawPos[i] = rawPos[i];
      if (!NEWstring_encoder){
      Serial.print("e");
      Serial.print(i);
      Serial.print(" ");
      Serial.println(rawPos[i]);
      }else{
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
     Serial.println(int(rawPos[i]));
        }
    }
  
  #endif

    #ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED 2");
  #endif

  #ifndef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод в порт ПК текущего состояния энкодера
      oldRawPos[i] = rawPos[i];
      if(rawPos[i] == 255){
        #ifdef DEBUG
          Serial.print("e");
          Serial.print(i);
          Serial.print(" ");
          Serial.println("ERROR");
        #endif
        encPos[i] = encBorder[i][0];
      }
      else{
        if (rawBorder[i][0] < rawBorder[i][1]){
          rawNorm[i] = rawBorder[i][1] - rawBorder[i][0];
          encPoint[i] = (rawBorder[i][0] + 128 - rawBorder[i][1] - 1) / 2.0;
          if(rawBorder[i][0] < encPoint[i]){
            encPoint[i] += rawBorder[i][1];
          }
          else{
            encPoint[i] -= rawBorder[i][0];
          }
          if(encPoint[i] > 0){
            if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if((rawPos[i] < encPoint[i]) && (rawPos[i] >= rawBorder[i][1])){
              encPos[i] = 1.00;
            }
            else{
              encPos[i] = 0.00;
            }
          }
          else{
            if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])){
              encPos[i] = 0.00;
            }
            else{
              encPos[i] = 1.00;
            }
          }
        }
        else{
          rawNorm[i] = 128 - rawBorder[i][0] + rawBorder[i][1] + 1;
          encPoint[i] = (rawBorder[i][0] - rawBorder[i][1] - 1) / 2.0;
          encPoint[i] += rawBorder[i][1];
          if(rawPos[i] >= rawBorder[i][0]){
            encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
          }
          else if(rawPos[i] <= rawBorder[i][1]){
            encPos[i] = (rawPos[i] + 128 - rawBorder[i][0]) / rawNorm[i];
          }
          else if(rawPos[i] < encPoint[i]){
            encPos[i] = 1.00;
          }
          else{
            encPos[i] = 0.00;
          }
        }
  
        if(encType[i] == 0){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
        }
  
        if(encType[i] == 1){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
          if(encPos[i] == encBorder[i][1]){
            encPos[i] = encBorder[i][0];
          }
        }

        if(encType[i] == 2){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0])) * 5.0;
          if(encPos[i] == encBorder[i][1]){
            encPos[i] = encBorder[i][0];
          }
        }

        if(encType[i] == 4){
          encPos[i] = round(encPos[i] * 100)  / 100.0;
        }
      }
      oldEncPos[i] = encPos[i];
      if (!NEWstring_encoder){
      Serial.print("e");
      Serial.print(i);
      Serial.print(" ");
      Serial.print(encPos[i]);
      Serial.println("z");
      n++;
      }else{
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.print(int(encPos[i]));     
      Serial.println(); 
        }
    }

  #endif


   #ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED 3");
  #endif





 
for (i = 0; i < BUTTNUM_B; i++) {
    pinMode(buttPin_B[i], INPUT); // Настройка пина на вход
    digitalWrite(buttPin_B[i], HIGH); // Подтяжка пина к питанию
  }
  for (i = 0; i < BUTTNUM_B; i++) { // Опрос кнопок
    if (buttRev_B[i] == false) {
      if (digitalRead(buttPin_B[i]) == HIGH) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_B);
        Serial.print(" off");
        Serial.println("z");
        }else{
        Serial.print(character_B);
        Serial.print("#");
        Serial.print(i + butADD_B);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
      }
      else if (digitalRead(buttPin_B[i]) == LOW) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_B);
        Serial.print(" on");
        Serial.println("z");
        buttPos_B[i] = true;
         }else{
        Serial.print(character_B);
        Serial.print("#");
        Serial.print(i + butADD_B);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
        buttPos_B[i] = true;
          }
      }
    }
    else {
      if (digitalRead(buttPin_B[i]) == HIGH) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_B);
        Serial.print(" on");
        Serial.println("z");
        buttPos_B[i] = true;
         }else{
        Serial.print(character_B);
        Serial.print("#");
        Serial.print(i + butADD_B);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
        buttPos_B[i] = true;
          }
      }
      else if (digitalRead(buttPin_B[i]) == LOW) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_B);
        Serial.print(" off");
        Serial.println("z");
         }else{
        Serial.print(character_B);
        Serial.print("#");
        Serial.print(i + butADD_B);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
      }
    }
    n++;
  }

  for (i = 0; i < BUTTNUM_A; i++) {
    pinMode(buttPin_A[i], INPUT); // Настройка пина на вход
    digitalWrite(buttPin_A[i], HIGH); // Подтяжка пина к питанию
  }
  for (i = 0; i < BUTTNUM_A; i++) { // Опрос кнопок
    if (buttRev_A[i] == false) {
      if (digitalRead(buttPin_A[i]) == HIGH) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_A);
        Serial.print(" off");
        Serial.println("z");
        }else{
        Serial.print(character_A);
        Serial.print("#");
        Serial.print(i + butADD_A);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
      }
      else if (digitalRead(buttPin_A[i]) == LOW) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_A);
        Serial.print(" on");
        Serial.println("z");
        buttPos_A[i] = true;
         }else{
        Serial.print(character_A);
        Serial.print("#");
        Serial.print(i + butADD_A);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
        buttPos_A[i] = true;
          }
      }
    }
    else {
      if (digitalRead(buttPin_A[i]) == HIGH) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_A);
        Serial.print(" on");
        Serial.println("z");
        buttPos_A[i] = true;
         }else{
        Serial.print(character_A);
        Serial.print("#");
        Serial.print(i + butADD_A);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
        buttPos_A[i] = true;
          }
      }
      else if (digitalRead(buttPin_A[i]) == LOW) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_A);
        Serial.print(" off");
        Serial.println("z");
         }else{
        Serial.print(character_A);
        Serial.print("#");
        Serial.print(i + butADD_A);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
      }
    }
    n++;
  }


// Инициализация
  pcfH.begin(); 
// Настройка пинов
  for(i = 0; i < PCF_H_ELEM_NUM; i++){ 
    pcfH.gpioPinMode(pcfHelemPin[i], INPUT_PULLUP); 
  }
// Опрос
  for(i = 0; i < PCF_H_ELEM_NUM; i++){ 
    if(pcfHelemRev[i] == false){
      if(pcfH.gpioDigitalRead(pcfHelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfHADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfHADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfHelemPos[i] = false;   
      }
      else if(pcfH.gpioDigitalRead(pcfHelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfHADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfHADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfHelemPos[i] = true;      
      } 
    }
    else{
      if(pcfH.gpioDigitalRead(pcfHelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfHADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfHADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfHelemPos[i] = true;  
      }
      else if(pcfH.gpioDigitalRead(pcfHelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfHADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfHADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfHelemPos[i] = false;  
      } 
    }
    n++;
    pcfHelemTime[i] = millis();
  } 

// Инициализация
  pcfI.begin(); 
// Настройка пинов
  for(i = 0; i < PCF_I_ELEM_NUM; i++){ 
    pcfI.gpioPinMode(pcfIelemPin[i], INPUT_PULLUP); 
  }
// Опрос
  for(i = 0; i < PCF_I_ELEM_NUM; i++){ 
    if(pcfIelemRev[i] == false){
      if(pcfI.gpioDigitalRead(pcfIelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfIADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfIADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfIelemPos[i] = false;   
      }
      else if(pcfI.gpioDigitalRead(pcfIelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfIADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfIADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfIelemPos[i] = true;      
      } 
    }
    else{
      if(pcfI.gpioDigitalRead(pcfIelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfIADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfIADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfIelemPos[i] = true;  
      }
      else if(pcfI.gpioDigitalRead(pcfIelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfIADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfIADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfIelemPos[i] = false;  
      } 
    }
    n++;
    pcfIelemTime[i] = millis();
  } 

  pcfG.begin(); 
// Настройка пинов
  for(i = 0; i < PCF_G_ELEM_NUM; i++){ 
    pcfG.gpioPinMode(pcfGelemPin[i], INPUT_PULLUP); 
  }
// Опрос
  for(i = 0; i < PCF_G_ELEM_NUM; i++){ 
    if(pcfGelemRev[i] == false){
      if(pcfG.gpioDigitalRead(pcfGelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfGADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfGADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfGelemPos[i] = false;   
      }
      else if(pcfG.gpioDigitalRead(pcfGelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfGADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfGADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfGelemPos[i] = true;      
      } 
    }
    else{
      if(pcfG.gpioDigitalRead(pcfGelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfGADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfGADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfGelemPos[i] = true;  
      }
      else if(pcfG.gpioDigitalRead(pcfGelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfGADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfGADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfGelemPos[i] = false;  
      } 
    }
    n++;
    pcfGelemTime[i] = millis();
  } 

 pcfF.begin(); 
// Настройка пинов
  for(i = 0; i < PCF_F_ELEM_NUM; i++){ 
    pcfF.gpioPinMode(pcfFelemPin[i], INPUT_PULLUP); 
  }
// Опрос
  for(i = 0; i < PCF_F_ELEM_NUM; i++){ 
    if(pcfFelemRev[i] == false){
      if(pcfF.gpioDigitalRead(pcfFelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfFADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfFADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfFelemPos[i] = false;   
      }
      else if(pcfF.gpioDigitalRead(pcfFelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfFADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfFADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfFelemPos[i] = true;      
      } 
    }
    else{
      if(pcfF.gpioDigitalRead(pcfFelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfFADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfFADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfFelemPos[i] = true;  
      }
      else if(pcfF.gpioDigitalRead(pcfFelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfFADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfFADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfFelemPos[i] = false;  
      } 
    }
    n++;
    pcfFelemTime[i] = millis();
  } 
 // Инициализация
  pcfD.begin(); 
// Настройка пинов
  for(i = 0; i < PCF_D_ELEM_NUM; i++){ 
    pcfD.gpioPinMode(pcfDelemPin[i], INPUT_PULLUP); 
  }
// Опрос
  for(i = 0; i < PCF_D_ELEM_NUM; i++){ 
    if(pcfDelemRev[i] == false){
      if(pcfD.gpioDigitalRead(pcfDelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfDADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfDADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfDelemPos[i] = false;   
      }
      else if(pcfD.gpioDigitalRead(pcfDelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfDADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfDADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfDelemPos[i] = true;      
      } 
    }
    else{
      if(pcfD.gpioDigitalRead(pcfDelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfDADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfDADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfDelemPos[i] = true;  
      }
      else if(pcfD.gpioDigitalRead(pcfDelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfDADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfDADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfDelemPos[i] = false;  
      } 
    }
    n++;
    pcfDelemTime[i] = millis();
  } 

 // Инициализация
  pcfC.begin(); 
// Настройка пинов
  for(i = 0; i < PCF_C_ELEM_NUM; i++){ 
    pcfC.gpioPinMode(pcfCelemPin[i], INPUT_PULLUP); 
  }
// Опрос
  for(i = 0; i < PCF_C_ELEM_NUM; i++){ 
    if(pcfCelemRev[i] == false){
      if(pcfC.gpioDigitalRead(pcfCelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfCADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfCADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfCelemPos[i] = false;   
      }
      else if(pcfC.gpioDigitalRead(pcfCelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfCADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfCADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfCelemPos[i] = true;      
      } 
    }
    else{
      if(pcfC.gpioDigitalRead(pcfCelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfCADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfCADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfCelemPos[i] = true;  
      }
      else if(pcfC.gpioDigitalRead(pcfCelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfCADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfCADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfCelemPos[i] = false;  
      } 
    }
    n++;
    pcfCelemTime[i] = millis();
  } 

// Инициализация
  pcfB.begin(); 
// Настройка пинов
  for(i = 0; i < PCF_B_ELEM_NUM; i++){ 
    pcfB.gpioPinMode(pcfBelemPin[i], INPUT_PULLUP); 
  }
// Опрос
  for(i = 0; i < PCF_B_ELEM_NUM; i++){ 
    if(pcfBelemRev[i] == false){
      if(pcfB.gpioDigitalRead(pcfBelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfBADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfBADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfBelemPos[i] = false;   
      }
      else if(pcfB.gpioDigitalRead(pcfBelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfBADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfBADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfBelemPos[i] = true;      
      } 
    }
    else{
      if(pcfB.gpioDigitalRead(pcfBelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfBADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfBADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfBelemPos[i] = true;  
      }
      else if(pcfB.gpioDigitalRead(pcfBelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfBADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfBADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfBelemPos[i] = false;  
      } 
    }
    n++;
    pcfBelemTime[i] = millis();
  } 

 
// Инициализация
  pcfA.begin(); 
// Настройка пинов
  for(i = 0; i < PCF_A_ELEM_NUM; i++){ 
    pcfA.gpioPinMode(pcfAelemPin[i], INPUT_PULLUP); 
  }
// Опрос
  for(i = 0; i < PCF_A_ELEM_NUM; i++){ 
    if(pcfAelemRev[i] == false){
      if(pcfA.gpioDigitalRead(pcfAelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfAADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfAADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfAelemPos[i] = false;   
      }
      else if(pcfA.gpioDigitalRead(pcfAelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfAADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfAADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfAelemPos[i] = true;      
      } 
    }
    else{
      if(pcfA.gpioDigitalRead(pcfAelemPin[i]) == HIGH){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfAADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfAADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

        pcfAelemPos[i] = true;  
      }
      else if(pcfA.gpioDigitalRead(pcfAelemPin[i]) == LOW){
          if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfAADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfAADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfAelemPos[i] = false;  
      } 
    }
    n++;
    pcfAelemTime[i] = millis();
  } 
  Serial.println("stop");
}

void loop() {

  
  // put your main code here, to run repeatedly:
 for(i = 0; i < PCF_D_ELEM_NUM; i++){ // Опрос
    if(pcfDelemRev[i] == false){
      if((pcfD.gpioDigitalRead(pcfDelemPin[i]) == HIGH) && (pcfDelemPos[i] == true)){
        if((millis() - pcfDelemTime[i]) > pcfDelemDelay[i]){
            if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i+ pcfDADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfDADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfDelemTime[i] = millis();
          pcfDelemPos[i] = false; 
        }
      }
      else if((pcfD.gpioDigitalRead(pcfDelemPin[i]) == LOW) && (pcfDelemPos[i] == false)){
        if((millis() - pcfDelemTime[i]) > pcfDelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfDADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfDADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfDelemTime[i] = millis();
          pcfDelemPos[i] = true; 
        }      
      } 
    }
    else{
      if((pcfD.gpioDigitalRead(pcfDelemPin[i]) == HIGH) && (pcfDelemPos[i] == false)){
        if((millis() - pcfDelemTime[i]) > pcfDelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfDADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfDADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfDelemPos[i] = true; 
        }      
      }
      else if((pcfD.gpioDigitalRead(pcfDelemPin[i]) == LOW) && (pcfDelemPos[i] == true)){
        if((millis() - pcfDelemTime[i]) > pcfDelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfDADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfDelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfDADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfDelemTime[i] = millis();
          pcfDelemPos[i] = false; 
        }  
      } 
    }
  }

  
  // put your main code here, to run repeatedly:
 for(i = 0; i < PCF_C_ELEM_NUM; i++){ // Опрос
    if(pcfCelemRev[i] == false){
      if((pcfC.gpioDigitalRead(pcfCelemPin[i]) == HIGH) && (pcfCelemPos[i] == true)){
        if((millis() - pcfCelemTime[i]) > pcfCelemDelay[i]){
            if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i+ pcfCADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfCADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfCelemTime[i] = millis();
          pcfCelemPos[i] = false; 
        }
      }
      else if((pcfC.gpioDigitalRead(pcfCelemPin[i]) == LOW) && (pcfCelemPos[i] == false)){
        if((millis() - pcfCelemTime[i]) > pcfCelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfCADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfCADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfCelemTime[i] = millis();
          pcfCelemPos[i] = true; 
        }      
      } 
    }
    else{
      if((pcfC.gpioDigitalRead(pcfCelemPin[i]) == HIGH) && (pcfCelemPos[i] == false)){
        if((millis() - pcfCelemTime[i]) > pcfCelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfCADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfCADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfCelemPos[i] = true; 
        }      
      }
      else if((pcfC.gpioDigitalRead(pcfCelemPin[i]) == LOW) && (pcfCelemPos[i] == true)){
        if((millis() - pcfCelemTime[i]) > pcfCelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfCADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfCelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfCADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfCelemTime[i] = millis();
          pcfCelemPos[i] = false; 
        }  
      } 
    }
  }

    // put your main code here, to run repeatedly:
 for(i = 0; i < PCF_B_ELEM_NUM; i++){ // Опрос
    if(pcfBelemRev[i] == false){
      if((pcfB.gpioDigitalRead(pcfBelemPin[i]) == HIGH) && (pcfBelemPos[i] == true)){
        if((millis() - pcfBelemTime[i]) > pcfBelemDelay[i]){
            if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i+ pcfBADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfBADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfBelemTime[i] = millis();
          pcfBelemPos[i] = false; 
        }
      }
      else if((pcfB.gpioDigitalRead(pcfBelemPin[i]) == LOW) && (pcfBelemPos[i] == false)){
        if((millis() - pcfBelemTime[i]) > pcfBelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfBADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfBADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfBelemTime[i] = millis();
          pcfBelemPos[i] = true; 
        }      
      } 
    }
    else{
      if((pcfB.gpioDigitalRead(pcfBelemPin[i]) == HIGH) && (pcfBelemPos[i] == false)){
        if((millis() - pcfBelemTime[i]) > pcfBelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfBADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfBADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfBelemPos[i] = true; 
        }      
      }
      else if((pcfB.gpioDigitalRead(pcfBelemPin[i]) == LOW) && (pcfBelemPos[i] == true)){
        if((millis() - pcfBelemTime[i]) > pcfBelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfBADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfBelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfBADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfBelemTime[i] = millis();
          pcfBelemPos[i] = false; 
        }  
      } 
    }
  }
  // put your main code here, to run repeatedly:
 for(i = 0; i < PCF_A_ELEM_NUM; i++){ // Опрос
    if(pcfAelemRev[i] == false){
      if((pcfA.gpioDigitalRead(pcfAelemPin[i]) == HIGH) && (pcfAelemPos[i] == true)){
        if((millis() - pcfAelemTime[i]) > pcfAelemDelay[i]){
            if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i+ pcfAADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfAADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfAelemTime[i] = millis();
          pcfAelemPos[i] = false; 
        }
      }
      else if((pcfA.gpioDigitalRead(pcfAelemPin[i]) == LOW) && (pcfAelemPos[i] == false)){
        if((millis() - pcfAelemTime[i]) > pcfAelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfAADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfAADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfAelemTime[i] = millis();
          pcfAelemPos[i] = true; 
        }      
      } 
    }
    else{
      if((pcfA.gpioDigitalRead(pcfAelemPin[i]) == HIGH) && (pcfAelemPos[i] == false)){
        if((millis() - pcfAelemTime[i]) > pcfAelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfAADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfAADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfAelemPos[i] = true; 
        }      
      }
      else if((pcfA.gpioDigitalRead(pcfAelemPin[i]) == LOW) && (pcfAelemPos[i] == true)){
        if((millis() - pcfAelemTime[i]) > pcfAelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfAADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfAelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfAADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfAelemTime[i] = millis();
          pcfAelemPos[i] = false; 
        }  
      } 
    }
  }


  
  // put your main code here, to run repeatedly:
 for(i = 0; i < PCF_F_ELEM_NUM; i++){ // Опрос
    if(pcfFelemRev[i] == false){
      if((pcfF.gpioDigitalRead(pcfFelemPin[i]) == HIGH) && (pcfFelemPos[i] == true)){
        if((millis() - pcfFelemTime[i]) > pcfFelemDelay[i]){
            if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i+ pcfFADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfFADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfFelemTime[i] = millis();
          pcfFelemPos[i] = false; 
        }
      }
      else if((pcfF.gpioDigitalRead(pcfFelemPin[i]) == LOW) && (pcfFelemPos[i] == false)){
        if((millis() - pcfFelemTime[i]) > pcfFelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfFADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfFADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfFelemTime[i] = millis();
          pcfFelemPos[i] = true; 
        }      
      } 
    }
    else{
      if((pcfF.gpioDigitalRead(pcfFelemPin[i]) == HIGH) && (pcfFelemPos[i] == false)){
        if((millis() - pcfFelemTime[i]) > pcfFelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfFADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfFADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfFelemPos[i] = true; 
        }      
      }
      else if((pcfF.gpioDigitalRead(pcfFelemPin[i]) == LOW) && (pcfFelemPos[i] == true)){
        if((millis() - pcfFelemTime[i]) > pcfFelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfFADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfFelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfFADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfFelemTime[i] = millis();
          pcfFelemPos[i] = false; 
        }  
      } 
    }
  }
  
  // put your main code here, to run repeatedly:
 for(i = 0; i < PCF_G_ELEM_NUM; i++){ // Опрос
    if(pcfGelemRev[i] == false){
      if((pcfG.gpioDigitalRead(pcfGelemPin[i]) == HIGH) && (pcfGelemPos[i] == true)){
        if((millis() - pcfGelemTime[i]) > pcfGelemDelay[i]){
            if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i+ pcfGADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfGADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfGelemTime[i] = millis();
          pcfGelemPos[i] = false; 
        }
      }
      else if((pcfG.gpioDigitalRead(pcfGelemPin[i]) == LOW) && (pcfGelemPos[i] == false)){
        if((millis() - pcfGelemTime[i]) > pcfGelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfGADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfGADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfGelemTime[i] = millis();
          pcfGelemPos[i] = true; 
        }      
      } 
    }
    else{
      if((pcfG.gpioDigitalRead(pcfGelemPin[i]) == HIGH) && (pcfGelemPos[i] == false)){
        if((millis() - pcfGelemTime[i]) > pcfGelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfGADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfGADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfGelemPos[i] = true; 
        }      
      }
      else if((pcfG.gpioDigitalRead(pcfGelemPin[i]) == LOW) && (pcfGelemPos[i] == true)){
        if((millis() - pcfGelemTime[i]) > pcfGelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfGADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfGelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfGADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfGelemTime[i] = millis();
          pcfGelemPos[i] = false; 
        }  
      } 
    }
  }
  for(i = 0; i < PCF_I_ELEM_NUM; i++){ // Опрос
    if(pcfIelemRev[i] == false){
      if((pcfI.gpioDigitalRead(pcfIelemPin[i]) == HIGH) && (pcfIelemPos[i] == true)){
        if((millis() - pcfIelemTime[i]) > pcfIelemDelay[i]){
            if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i+ pcfIADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfIADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfIelemTime[i] = millis();
          pcfIelemPos[i] = false; 
        }
      }
      else if((pcfI.gpioDigitalRead(pcfIelemPin[i]) == LOW) && (pcfIelemPos[i] == false)){
        if((millis() - pcfIelemTime[i]) > pcfIelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfIADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfIADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfIelemTime[i] = millis();
          pcfIelemPos[i] = true; 
        }      
      } 
    }
    else{
      if((pcfI.gpioDigitalRead(pcfIelemPin[i]) == HIGH) && (pcfIelemPos[i] == false)){
        if((millis() - pcfIelemTime[i]) > pcfIelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfIADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfIADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfIelemPos[i] = true; 
        }      
      }
      else if((pcfI.gpioDigitalRead(pcfIelemPin[i]) == LOW) && (pcfIelemPos[i] == true)){
        if((millis() - pcfIelemTime[i]) > pcfIelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfIADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfIelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfIADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfIelemTime[i] = millis();
          pcfIelemPos[i] = false; 
        }  
      } 
    }
  }
  
  // put your main code here, to run repeatedly:
 for(i = 0; i < PCF_H_ELEM_NUM; i++){ // Опрос
    if(pcfHelemRev[i] == false){
      if((pcfH.gpioDigitalRead(pcfHelemPin[i]) == HIGH) && (pcfHelemPos[i] == true)){
        if((millis() - pcfHelemTime[i]) > pcfHelemDelay[i]){
            if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i+ pcfHADDints);
        Serial.print(" off");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfHADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }

          pcfHelemTime[i] = millis();
          pcfHelemPos[i] = false; 
        }
      }
      else if((pcfH.gpioDigitalRead(pcfHelemPin[i]) == LOW) && (pcfHelemPos[i] == false)){
        if((millis() - pcfHelemTime[i]) > pcfHelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfHADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfHADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfHelemTime[i] = millis();
          pcfHelemPos[i] = true; 
        }      
      } 
    }
    else{
      if((pcfH.gpioDigitalRead(pcfHelemPin[i]) == HIGH) && (pcfHelemPos[i] == false)){
        if((millis() - pcfHelemTime[i]) > pcfHelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfHADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfHADDints);
        Serial.print("#");
        Serial.print("1");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfHelemPos[i] = true; 
        }      
      }
      else if((pcfH.gpioDigitalRead(pcfHelemPin[i]) == LOW) && (pcfHelemPos[i] == true)){
        if((millis() - pcfHelemTime[i]) > pcfHelemDelay[i]){
           if(!PrintUNITY){
            if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
        Serial.print("b");
        if (!notKPAPrint){
                if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print(i + pcfHADDints);
        Serial.print(" on");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
        }else{
          if (testPrint){
        Serial.print(arduinoSymbol);
        Serial.print(pcfHelemSymbol);
        }
         Serial.print("b");
        if (notKPAPrint){       
        if(i < 10){
          Serial.print(0);
        }
        }
        Serial.print("#");
        Serial.print(i + pcfHADDints);
        Serial.print("#");
        Serial.print("0");
        if(PrintZ){
        Serial.println(endSymbol);
        }else{
         Serial.println(); 
          }
          
          }
          pcfHelemTime[i] = millis();
          pcfHelemPos[i] = false; 
        }  
      } 
    }
  }

    //        РАБОТА КНОПОК                                                           //
  ////                                                                            ////
  for (int i = 0; i < BUTTNUM_A; i++) { // Опрос кнопок
    if (buttRev_A[i] == false) {
      if ((digitalRead(buttPin_A[i]) == HIGH) && (buttPos_A[i] == true)) {
        t = millis();
        if ((t - buttTime_A[i]) > BUTTDELAY_A) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_A);
          Serial.print(" off");
          Serial.println("z");
           }else{
        Serial.print(character_A);
        Serial.print("#");
        Serial.print(i + butADD_A);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
          buttTime_A[i] = t;
          buttPos_A[i] = false;
        }
      }
      else if ((digitalRead(buttPin_A[i]) == LOW) && (buttPos_A[i] == false)) {
        t = millis();
        if ((t - buttTime_A[i]) > BUTTDELAY_A) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_A);
          Serial.print(" on");
          Serial.println("z");
           }else{
        Serial.print(character_A);
        Serial.print("#");
        Serial.print(i + butADD_A);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
          }
          buttTime_A[i] = t;
          buttPos_A[i] = true;
        }
      }
    }
    else {
      if ((digitalRead(buttPin_A[i]) == HIGH) && (buttPos_A[i] == false)) {
        t = millis();
        if ((t - buttTime_A[i]) > BUTTDELAY_A) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_A);
          Serial.print(" on");
          Serial.println("z");
           }else{
        Serial.print(character_A);
        Serial.print("#");
        Serial.print(i + butADD_A);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
          }
          buttTime_A[i] = t;
          buttPos_A[i] = true;
        }
      }
      else if ((digitalRead(buttPin_A[i]) == LOW) && (buttPos_A[i] == true)) {
        t = millis();
        if ((t - buttTime_A[i]) > BUTTDELAY_A) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_A);
          Serial.print(" off");
          Serial.println("z");
           }else{
        Serial.print(character_A);
        Serial.print("#");
        Serial.print(i + butADD_A);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
          buttTime_A[i] = t;
          buttPos_A[i] = false;
        }
      }
    }
  }

    //        РАБОТА КНОПОК                                                           //
  ////                                                                            ////
  for (int i = 0; i < BUTTNUM_B; i++) { // Опрос кнопок
    if (buttRev_B[i] == false) {
      if ((digitalRead(buttPin_B[i]) == HIGH) && (buttPos_B[i] == true)) {
        t = millis();
        if ((t - buttTime_B[i]) > BUTTDELAY_B) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_B);
          Serial.print(" off");
          Serial.println("z");
           }else{
        Serial.print(character_B);
        Serial.print("#");
        Serial.print(i + butADD_B);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
          buttTime_B[i] = t;
          buttPos_B[i] = false;
        }
      }
      else if ((digitalRead(buttPin_B[i]) == LOW) && (buttPos_B[i] == false)) {
        t = millis();
        if ((t - buttTime_B[i]) > BUTTDELAY_B) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_B);
          Serial.print(" on");
          Serial.println("z");
           }else{
        Serial.print(character_B);
        Serial.print("#");
        Serial.print(i + butADD_B);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
          }
          buttTime_B[i] = t;
          buttPos_B[i] = true;
        }
      }
    }
    else {
      if ((digitalRead(buttPin_B[i]) == HIGH) && (buttPos_B[i] == false)) {
        t = millis();
        if ((t - buttTime_B[i]) > BUTTDELAY_B) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_B);
          Serial.print(" on");
          Serial.println("z");
           }else{
        Serial.print(character_B);
        Serial.print("#");
        Serial.print(i + butADD_B);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
          }
          buttTime_B[i] = t;
          buttPos_B[i] = true;
        }
      }
      else if ((digitalRead(buttPin_B[i]) == LOW) && (buttPos_B[i] == true)) {
        t = millis();
        if ((t - buttTime_B[i]) > BUTTDELAY_B) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_B);
          Serial.print(" off");
          Serial.println("z");
           }else{
        Serial.print(character_B);
        Serial.print("#");
        Serial.print(i + butADD_B);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
          buttTime_B[i] = t;
          buttPos_B[i] = false;
        }
      }
    }
  }
   rawPos[0] = enc0.rawPos();
  rawPos[1] = enc1.rawPos();
    #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){
      if (rawPos[i] != oldRawPos[i]){ // Вывод текущего положения энкодера при наличии изменений
        oldRawPos[i] = rawPos[i];  
        if(!NEWstring_encoder){   
        Serial.print("e");
        Serial.print(i);
        Serial.print(" ");
        
        Serial.println(rawPos[i]);
        }else{
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      
      Serial.print(int(rawPos[i]));   
      Serial.println(".00");
        }
      }
    }
  #endif

  #ifndef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод в порт ПК текущего состояния энкодера
      if (rawPos[i] != oldRawPos[i]){
        oldRawPos[i] = rawPos[i];
        if(rawPos[i] == 255){
          #ifdef DEBUG
            Serial.print("e");
            Serial.print(i);
            Serial.print(" ");
            Serial.println("ERROR");
          #endif
        }
        else{
          if (rawBorder[i][0] < rawBorder[i][1]){
            if(encPoint[i] > 0){
              if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
                encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
              }
              else if((rawPos[i] < encPoint[i]) && (rawPos[i] >= rawBorder[i][1])){
                encPos[i] = 1.00;
              }
              else{
                encPos[i] = 0.00;
              }
            }
            else{
              if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
                encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
              }
              else if((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])){
                encPos[i] = 0.00;
              }
              else{
                encPos[i] = 1.00;
              }
            }
          }
          else{
            if(rawPos[i] >= rawBorder[i][0]){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if(rawPos[i] <= rawBorder[i][1]){
              encPos[i] = (rawPos[i] + 128 - rawBorder[i][0]) / rawNorm[i];
            }
            else if(rawPos[i] < encPoint[i]){
              encPos[i] = 1.00;
            }
            else{
              encPos[i] = 0.00;
            }
          }
    
          if(encType[i] == 0){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
          }

          if(encType[i] == 1){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
            if(encPos[i] == encBorder[i][1]){
              encPos[i] = encBorder[i][0];
            }
          }

          if(encType[i] == 2){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0])) * 5.0;
            if(encPos[i] == encBorder[i][1]){
              encPos[i] = encBorder[i][0];
            }
          }

          if(encType[i] == 4){
            encPos[i] = round(encPos[i] * 100)  / 100.0;
          }
          
          if(encPos[i] != oldEncPos[i]){
            oldEncPos[i] = encPos[i];
            if(!NEWstring_encoder){
            Serial.print("e");
            Serial.print(i);
            Serial.print(" ");
            Serial.print(encPos[i]);
            Serial.println("z");
            }else{
            Serial.print("e"); 
            Serial.print("#"); 
            Serial.print(i);
            Serial.print("#"); 
           

             Serial.print(int(encPos[i]));
      Serial.println(".00");
            
              }
          }
        }
      }
    }

  #endif

for (int i = 0; i < BUTTNUM_C; i++) { // Опрос кнопок
    if (buttRev_C[i] == false) {
      if ((digitalRead(buttPin_C[i]) == HIGH) && (buttPos_C[i] == true)) {
        t = millis();
        if ((t - buttTime_C[i]) > BUTTDELAY_C) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_C);
          Serial.print(" off");
          Serial.println("z");
           }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
          buttTime_C[i] = t;
          buttPos_C[i] = false;
        }
      }
      else if ((digitalRead(buttPin_C[i]) == LOW) && (buttPos_C[i] == false)) {
        t = millis();
        if ((t - buttTime_C[i]) > BUTTDELAY_C) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_C);
          Serial.print(" on");
          Serial.println("z");
           }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
          }
          buttTime_C[i] = t;
          buttPos_C[i] = true;
        }
      }
    }
    else {
      if ((digitalRead(buttPin_C[i]) == HIGH) && (buttPos_C[i] == false)) {
        t = millis();
        if ((t - buttTime_C[i]) > BUTTDELAY_C) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_C);
          Serial.print(" on");
          Serial.println("z");
           }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
          }
          buttTime_C[i] = t;
          buttPos_C[i] = true;
        }
      }
      else if ((digitalRead(buttPin_C[i]) == LOW) && (buttPos_C[i] == true)) {
        t = millis();
        if ((t - buttTime_C[i]) > BUTTDELAY_C) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_C);
          Serial.print(" off");
          Serial.println("z");
           }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
          buttTime_C[i] = t;
          buttPos_C[i] = false;
        }
      }
    }
  }






  if (Serial.available() > 0) { // Проверка, что есть данные
    str = Serial.readStringUntil('\n');
    
    
    
    ///////////////////////////////////////////////////NeoPixelBus Serial.available ////////////////////////////////////////
     if(str.substring(0, 2).equals("on")){
     if(str.substring(2, 3) != ""){
        i = str.substring(2, 5).toInt();  
        strip.SetPixelColor(i, hslWhite);
        strip.Show();
        }else{   
          for(i = 0; i < PixelCount; i++){
          strip.SetPixelColor(i, hslWhite);
          strip.Show();
        }
       }
      }
      else if(str.substring(0, 3).equals("off")){
     if(str.substring(3, 4) != ""){
        i = str.substring(3, 5).toInt();  
        strip.SetPixelColor(i, hslBlack);
        strip.Show();
        }else{
           for(i = 0; i < PixelCount; i++){
          strip.SetPixelColor(i, hslBlack);
          strip.Show();
        }
        } 
      }
    
    ///////////////////////////////////////////////////NeoPixelBus Serial.available ////////////////////////////////////////
    
    
    
    
    
    
    
    }

  
}
