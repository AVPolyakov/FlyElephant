﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FlyElephant.Program;

namespace FlyElephant.Tests
{
    [TestClass]
    public class Tests
    {
        private static string[] dictionary => new[] {"КОТ", "ТОН", "НОТА", "КОТЫ", "РОТ", "РОТА", "ТОТ"};

        [TestMethod]
        public void Example()
        {
            Assert.IsTrue(new[] {"КОТ", "ТОТ", "ТОН"}.SequenceEqual(
                FindChain("КОТ", "ТОН", dictionary).Value));
        }

        [TestMethod]
        public void FlyElephantExample()
        {
            Assert.AreEqual("муха-мура-кура-кара-каре-кафе-кафр-каир-каин-клин-клон-слон",
                string.Join("-", FindChain("муха", "слон",
                    "кафр урюк быть весь этот мочь один себя свое если рука даже свой дело есть глаз день надо идти друг тоже лицо ведь жить нога пока хотя сила вода куда стол ночь отец дать твой лишь свет жена окно мать утро душа таки чуть хоть уйти пять путь пора тело язык мама небо брат туда мало труд сюда чтоб тихо двор иной угол губа снег либо дядя мера край река рота речь гора едва море врач ясно боль вещь цель план пара след пить мимо враг удар мало вниз двое счет игра член хлеб банк идея союз метр вера бить звук роль петь поэт лист выше этаж дочь опыт рост кожа баба дама поле ящик цена зато тень лето воля цвет круг факт стул вино ради танк зима знак семь мозг рыба щека папа срок курс куст явно чудо тема крик ключ конь штаб пора трое ужас ссср очко пыль боец черт царь даль слух клуб беда обед тетя лечь смех злой мост пуля мясо долг рада пиво зона вход итак пост дача рано ниже кино горе вряд суть стен толк вкус полк кофе база урок труп муха лапа плащ нету шкаф сеть грех парк борт луна волк пила файл куча пояс гриб слой изба юный пища храм рана холм доля воин тьма итог боже гном цепь ужин баня жест щель узел гроб шанс порт июнь март перо яйцо туча верх нерв этап заяц дума роза кадр июль фонд ныне виза груз ярко внук стук печь мина хрен соль руль мука штат течь блок дура каша кафе лифт трус мода сено поза брак плод окоп сидя вина сбор флот мыло стоя гнев плюс змея один уход звон нквд пляж слон дыра бред риск взор лужа орел нары юбка рожа дата стыд ноль юмор учет вица флаг грек марш вена диск теща алый удав сего лыжа плач цирк бюро село мышь шуба роса упор рама указ кран хата поди сухо нуль дуть очаг шлем буря мрак матч коза темп гром холл веко тьфу стон сорт заря сейф визг млрд семя осел пруд офис гусь доза стоп елка змей тоня орех туго пена живо кпсс сало коса толь мыть ранг негр ритм стая блин азия тигр икра худо овца фара вяло плот клок купе сани кура даба чушь овощ цикл язва ныть лорд плат нить чаша эфир мощь уста секс скот винт жечь яхта литр роща крым нота лихо жанр лежа лить леди киев шрам вред нева ниша нрав миля яков трон лень зять выть игла дина троп дитя пень дико шнур кора уток штык укол прут мент тост джип крюк бокс толя прах лось свод фига клещ мазь ядро корм русь залп клей клад жара иуда граф сука бинт хаос плен тупо мгла жопа грош батя эльф няня кода такт ваза чара урал фаза дуга мочь пуща ложе этак пина безо дева псих фунт дуло клан паук трап рыло град нора ожог спор рака вить джин жать шить араб липа тасс гага рыть тяга близ чадо клоп арка чаек обои клык нато фото клюв бунт трос отек сема меню вата жила мисс кара урод эдак ляля крем утюг мило рига езда усик узор кнут босс приз медь тушь перс моча марс косо пакт сень мари орда веня борщ алло шелк чаща веер раса шарф враз торт кайф моща тура выпь уйма ноша гарь пики лада маяк долл стих карп майя вонь крах серо лига зубр плац урна нива горб зола взад иней мсье депо хрип бомж шина дурь руда джаз герб мара дорн соус кедр пузо хвоя рейд сеул стаж жаба морг урка клин опор шест заем сени кабы харя йога трюм чека саше ушко гимн ямка хлам стан дань ладо вилы трюк зной паек блик рема слог тина квас жгут муть шаль пред сайт пята дьяк клен сечь швед лунь лязг гувд обоз вмиг пони балл щука степ жало корж укор ввод дичь утес скат воск сера щелк гиря жрец сова ежик шейк гута ирак юнец раба огпу бюст шило филя бора кейс серп пани вбок писк укус дыня вишь срыв идол лира пари сыпь нона ряса гной экий харч овес лиса фрак ушиб крот мура фрау мэтр лавр стог шифр гипс оный подо баян краб оспа муза цент бишь зуда наст убор кипр кпрф рута сушь жлоб зонт тест сажа гриф бант сбой авто итар атом гуща храп амур деть байт моль эсер чума загс дыба лава спец ковш торг улей сода рейх иран падь лоно раис мэри бусы кило чело жижа фойе киль рысь ново герр омут сбыт бита лата факс омон ария мена жуть ларь стык грач дуэт ярус вдох сыро срез плуг вьюк сноп пуск люкс соло шурф тайм тара удел буги агат спой флер сруб явка цинк ринг мель омар ясли срам сити круп фуга спид умно кров печь уезд спад паче марь горн этюд гнет роба ярый глум тишь улов куда жюри брод боек софа мять кндр ялта лупа елей чили плюс юрта зонд репа прок чета хост трлн грим брус ирма фила плед сито арап кипа пирс треп кума цска стер тент лыко гать лоза путч доха куль жезл ухаб диво вага иглу чача гель нате глас сгиб суша айда корт пляс свая веха дюна опус клич корн понт яуза амир сток болт паря тута хлев фарш свищ кина ишак арат синь тула торс альт трах сыта бейт тора рябь пеня эфес алан бола арба прыщ блат топь угон кляп съем увар хлоп наин оное фура сход ласт высь дора пюре вошь выть шлюз путы жары рать ахти эмир скоп баул цаца дуля шутя пике эссе енот упад скит сыск финн лжец шлак межа вона мяло хорь дюйм бард овал азот барк фора узда угар тога форт снос перл уран мхат олин юнга трак вояж убег меря резь поем овин аист соха ткач дерн наем жбан злак сват каир обух каюк урон панк плес плов гран ящер нома вымя ринк лама рожь табу зуев нега ромб плющ морж едок янки изюм кома желе шлаг обет нимб баск гурд киса кепи любя усть ввоз ролл буде слет джем фарс щепа золь бега тире олух отит клев ласа ложа аозт сума куща каюр слых гкчп шейх блюз идиш бриз копа бяка фанк лдпр мана навь пядь каин тятя клеш рейн шмон тлен кофр блеф быль лаос люто шлях барс бура сырт сеид весь арык норд аура увал гонг хина озон скак плав убой чита лоск арфа ширь кока кета сноб вето вест омск кача вязь мавр адан крит берн едко сома рань слив скок фант темя ярок стек течь гнус морс смак трио охра мета тета сляб морт скуп гурт хром овен тата мзда узко корь соты зело серб зыбь сонм бель улан гост ворс пенс кипу иена обод фифа торф юрин титр финт зева ушат хрящ клон харт опий деев тюря кунг понг стяг алоэ бэби зоря тать кряж сказ сена дюже лгун туша мкад пума змий слом олим джей ажур крат усач купа паяц каре дзот копь блиц эпос гиви аоот ковы сван форс гунн лань мята скиф шпик жмот пасс натр хаус маки софт шарм плут рувд лука гоби немо пшик сыто фарт биль маго сага неуч лафа кали пион буян галл бета эвон голо челн крой риза саго беня опал фиат апис лото тпру лясы хаки вить имам ярмо жито спас анри крен вьюн хота фикс сбег юшка гарт чтец темь глот овод таец куга вира новь кото коми анус леер аман щорс рагу драп хрыч блуд хлыщ краз чаво жмых швея виль руза вега вече"
                        .Split(' ')).Value));
        }

        [TestMethod]
        public void WordsAreSame()
        {
            Assert.IsTrue(new[] {"КОТ"}.SequenceEqual(FindChain("КОТ", "КОТ", dictionary).Value));
        }

        [TestMethod]
        public void ArgsDifferentLengths()
        {
            Assert.IsFalse(FindChain("КОТ", "НОТА", dictionary).HasValue);
        }

        [TestMethod]
        public void StartWordNotInDictionary()
        {
            Assert.IsFalse(FindChain("КОТ", "ТОН", new[] {"ТОН", "НОТА", "КОТЫ", "РОТ", "РОТА", "ТОТ"}).HasValue);
        }

        [TestMethod]
        public void EndWordNotInDictionary()
        {
            Assert.IsFalse(FindChain("КОТ", "ТОН", new[] {"КОТ", "НОТА", "КОТЫ", "РОТ", "РОТА", "ТОТ"}).HasValue);
        }

        [TestMethod]
        public void StartWordIsEmpty()
        {
            Assert.IsFalse(FindChain("", "ТОН", dictionary).HasValue);
        }

        [TestMethod]
        public void EndWordIsEmpty()
        {
            Assert.IsFalse(FindChain("КОТ", "", dictionary).HasValue);
        }

        [TestMethod]
        public void WordsAreEmpty()
        {
            Assert.IsTrue(new[] {""}.SequenceEqual(FindChain("", "", new[] {""}).Value));
        }

        [TestMethod]
        public void DuplicatesInDictionary()
        {
            Assert.IsTrue(new[] {"КОТ", "ТОТ", "ТОН"}.SequenceEqual(
                FindChain("КОТ", "ТОН", new[] {"КОТ", "ТОН", "НОТА", "КОТЫ", "РОТ", "РОТА", "ТОТ", "ТОТ"}).Value));
        }

        [TestMethod]
        public void EmptyDictionary()
        {
            Assert.IsFalse(FindChain("КОТ", "КОТ", new string[] {}).HasValue);
        }

        [TestMethod]
        public void EmptyDictionary2()
        {
            Assert.IsFalse(FindChain("КОТ", "ТОН", new string[] {}).HasValue);
        }

        [TestMethod]
        public void SingleLetterWords()
        {
            Assert.IsTrue(new[] {"a", "b"}.SequenceEqual(FindChain("a", "b", new[] {"a", "b", "c"}).Value));
        }

        [TestMethod]
        public void SingleLetterWords2()
        {
            Assert.IsFalse(FindChain("a", "b", new[] {"c"}).HasValue);
        }

        private static string GetConsoleOutput(Action action)
        {
            var originalOut = Console.Out;
            string result;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                action();
                result = writer.ToString();
            }
            Console.SetOut(originalOut);
            return result;
        }

        public static string FindChainTest(string[] args, Func<string, IEnumerable<string>> readLines)
        {
            return GetConsoleOutput(() => FindChain(args, readLines));
        }

        private static string AppendLine(string value)
        {
            return $"{value}{Environment.NewLine}";
        }

        [TestMethod]
        public void StartEndPathIsNotSpecified()
        {
            Assert.AreEqual(AppendLine("Не задан путь к файлу, в котором указано начальное и конечное слово."), 
                FindChainTest(new string[] {}, path => new string[] {}));
        }

        [TestMethod]
        public void StartEndCouldNotFindFile()
        {
            Assert.AreEqual(AppendLine("Could not find file 'f1'."),
                FindChainTest(new[] {"f1"}, path => {
                    if (path == "f1") throw new FileNotFoundException("Could not find file 'f1'.");
                    return new string[] {};
                }));
        }

        [TestMethod]
        public void StartWordIsNotSpecified()
        {
            Assert.AreEqual(AppendLine("Не указано начальное слово."),
                FindChainTest(new[] {"f1"}, path => new string[] {}));
        }

        [TestMethod]
        public void EndtWordIsNotSpecified()
        {
            Assert.AreEqual(AppendLine("Не указано конечное слово."), 
                FindChainTest(new[] {"f1"}, path => new[] {"a"}));
        }

        [TestMethod]
        public void DictionaryPathIsNotSpecified()
        {
            Assert.AreEqual(AppendLine("Не задан путь к файлу, который содержит словарь."), 
                FindChainTest(new[] {"f1"}, path => new[] {"a", "b"}));
        }

        [TestMethod]
        public void DictionaryCouldNotFindFile()
        {
            Assert.AreEqual(AppendLine("Could not find file 'f2'."), 
                FindChainTest(new[] {"f1", "f2"}, path => {
                    if (path == "f2") throw new FileNotFoundException("Could not find file 'f2'.");
                    return new[] {"a", "b"};
                }));
        }

        [TestMethod]
        public void ExampleFiles()
        {
            Assert.AreEqual(@"КОТ
ТОТ
ТОН
", 
                FindChainTest(new[] {"f1", "f2"}, path => {
                    if (path == "f1") return new[] {"КОТ", "ТОН"};
                    if (path == "f2") return dictionary;
                    throw new ApplicationException();
                }));
        }

        [TestMethod]
        public void ThereIsNoChain()
        {
            Assert.AreEqual(AppendLine("Цепочки не существует."),
                FindChainTest(new[] {"f1", "f2"}, path => {
                    if (path == "f1") return new[] {"КОТ", "ТОН"};
                    if (path == "f2") return new[] {"КОТ", "ТОН"};
                    throw new ApplicationException();
                }));
        }
    }
}
