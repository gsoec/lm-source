.class public Lcom/igexin/push/extension/distribution/basic/i/b/j;
.super Ljava/lang/Object;


# static fields
.field private static final a:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Character;",
            ">;"
        }
    .end annotation
.end field

.field private static final b:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/Character;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private static final c:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/Character;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private static final d:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/Character;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private static final e:Ljava/util/regex/Pattern;

.field private static final f:Ljava/util/regex/Pattern;

.field private static final g:[[Ljava/lang/Object;


# direct methods
.method static constructor <clinit>()V
    .locals 9

    const/4 v5, 0x2

    const/4 v8, 0x1

    const/4 v2, 0x0

    const-string v0, "&(#(x|X)?([0-9a-fA-F]+)|[a-zA-Z]+\\d*);?"

    invoke-static {v0}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;)Ljava/util/regex/Pattern;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->e:Ljava/util/regex/Pattern;

    const-string v0, "&(#(x|X)?([0-9a-fA-F]+)|[a-zA-Z]+\\d*);"

    invoke-static {v0}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;)Ljava/util/regex/Pattern;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->f:Ljava/util/regex/Pattern;

    const/4 v0, 0x5

    new-array v0, v0, [[Ljava/lang/Object;

    new-array v1, v5, [Ljava/lang/Object;

    const-string v3, "quot"

    aput-object v3, v1, v2

    const/16 v3, 0x22

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    aput-object v3, v1, v8

    aput-object v1, v0, v2

    new-array v1, v5, [Ljava/lang/Object;

    const-string v3, "amp"

    aput-object v3, v1, v2

    const/16 v3, 0x26

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    aput-object v3, v1, v8

    aput-object v1, v0, v8

    new-array v1, v5, [Ljava/lang/Object;

    const-string v3, "apos"

    aput-object v3, v1, v2

    const/16 v3, 0x27

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    aput-object v3, v1, v8

    aput-object v1, v0, v5

    const/4 v1, 0x3

    new-array v3, v5, [Ljava/lang/Object;

    const-string v4, "lt"

    aput-object v4, v3, v2

    const/16 v4, 0x3c

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    aput-object v4, v3, v8

    aput-object v3, v0, v1

    const/4 v1, 0x4

    new-array v3, v5, [Ljava/lang/Object;

    const-string v4, "gt"

    aput-object v4, v3, v2

    const/16 v4, 0x3e

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    aput-object v4, v3, v8

    aput-object v3, v0, v1

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->g:[[Ljava/lang/Object;

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->b:Ljava/util/Map;

    const-string v0, "AElig=000C6\nAMP=00026\nAacute=000C1\nAcirc=000C2\nAgrave=000C0\nAring=000C5\nAtilde=000C3\nAuml=000C4\nCOPY=000A9\nCcedil=000C7\nETH=000D0\nEacute=000C9\nEcirc=000CA\nEgrave=000C8\nEuml=000CB\nGT=0003E\nIacute=000CD\nIcirc=000CE\nIgrave=000CC\nIuml=000CF\nLT=0003C\nNtilde=000D1\nOacute=000D3\nOcirc=000D4\nOgrave=000D2\nOslash=000D8\nOtilde=000D5\nOuml=000D6\nQUOT=00022\nREG=000AE\nTHORN=000DE\nUacute=000DA\nUcirc=000DB\nUgrave=000D9\nUuml=000DC\nYacute=000DD\naacute=000E1\nacirc=000E2\nacute=000B4\naelig=000E6\nagrave=000E0\namp=00026\naring=000E5\natilde=000E3\nauml=000E4\nbrvbar=000A6\nccedil=000E7\ncedil=000B8\ncent=000A2\ncopy=000A9\ncurren=000A4\ndeg=000B0\ndivide=000F7\neacute=000E9\necirc=000EA\negrave=000E8\neth=000F0\neuml=000EB\nfrac12=000BD\nfrac14=000BC\nfrac34=000BE\ngt=0003E\niacute=000ED\nicirc=000EE\niexcl=000A1\nigrave=000EC\niquest=000BF\niuml=000EF\nlaquo=000AB\nlt=0003C\nmacr=000AF\nmicro=000B5\nmiddot=000B7\nnbsp=000A0\nnot=000AC\nntilde=000F1\noacute=000F3\nocirc=000F4\nograve=000F2\nordf=000AA\nordm=000BA\noslash=000F8\notilde=000F5\nouml=000F6\npara=000B6\nplusmn=000B1\npound=000A3\nquot=00022\nraquo=000BB\nreg=000AE\nsect=000A7\nshy=000AD\nsup1=000B9\nsup2=000B2\nsup3=000B3\nszlig=000DF\nthorn=000FE\ntimes=000D7\nuacute=000FA\nucirc=000FB\nugrave=000F9\numl=000A8\nuuml=000FC\nyacute=000FD\nyen=000A5\nyuml=000FF\n"

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->c(Ljava/lang/String;)Ljava/util/Map;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a(Ljava/util/Map;)Ljava/util/Map;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->c:Ljava/util/Map;

    const-string v0, "AElig=000C6\nAMP=00026\nAacute=000C1\nAbreve=00102\nAcirc=000C2\nAcy=00410\nAfr=1D504\nAgrave=000C0\nAlpha=00391\nAmacr=00100\nAnd=02A53\nAogon=00104\nAopf=1D538\nApplyFunction=02061\nAring=000C5\nAscr=1D49C\nAssign=02254\nAtilde=000C3\nAuml=000C4\nBackslash=02216\nBarv=02AE7\nBarwed=02306\nBcy=00411\nBecause=02235\nBernoullis=0212C\nBeta=00392\nBfr=1D505\nBopf=1D539\nBreve=002D8\nBscr=0212C\nBumpeq=0224E\nCHcy=00427\nCOPY=000A9\nCacute=00106\nCap=022D2\nCapitalDifferentialD=02145\nCayleys=0212D\nCcaron=0010C\nCcedil=000C7\nCcirc=00108\nCconint=02230\nCdot=0010A\nCedilla=000B8\nCenterDot=000B7\nCfr=0212D\nChi=003A7\nCircleDot=02299\nCircleMinus=02296\nCirclePlus=02295\nCircleTimes=02297\nClockwiseContourIntegral=02232\nCloseCurlyDoubleQuote=0201D\nCloseCurlyQuote=02019\nColon=02237\nColone=02A74\nCongruent=02261\nConint=0222F\nContourIntegral=0222E\nCopf=02102\nCoproduct=02210\nCounterClockwiseContourIntegral=02233\nCross=02A2F\nCscr=1D49E\nCup=022D3\nCupCap=0224D\nDD=02145\nDDotrahd=02911\nDJcy=00402\nDScy=00405\nDZcy=0040F\nDagger=02021\nDarr=021A1\nDashv=02AE4\nDcaron=0010E\nDcy=00414\nDel=02207\nDelta=00394\nDfr=1D507\nDiacriticalAcute=000B4\nDiacriticalDot=002D9\nDiacriticalDoubleAcute=002DD\nDiacriticalGrave=00060\nDiacriticalTilde=002DC\nDiamond=022C4\nDifferentialD=02146\nDopf=1D53B\nDot=000A8\nDotDot=020DC\nDotEqual=02250\nDoubleContourIntegral=0222F\nDoubleDot=000A8\nDoubleDownArrow=021D3\nDoubleLeftArrow=021D0\nDoubleLeftRightArrow=021D4\nDoubleLeftTee=02AE4\nDoubleLongLeftArrow=027F8\nDoubleLongLeftRightArrow=027FA\nDoubleLongRightArrow=027F9\nDoubleRightArrow=021D2\nDoubleRightTee=022A8\nDoubleUpArrow=021D1\nDoubleUpDownArrow=021D5\nDoubleVerticalBar=02225\nDownArrow=02193\nDownArrowBar=02913\nDownArrowUpArrow=021F5\nDownBreve=00311\nDownLeftRightVector=02950\nDownLeftTeeVector=0295E\nDownLeftVector=021BD\nDownLeftVectorBar=02956\nDownRightTeeVector=0295F\nDownRightVector=021C1\nDownRightVectorBar=02957\nDownTee=022A4\nDownTeeArrow=021A7\nDownarrow=021D3\nDscr=1D49F\nDstrok=00110\nENG=0014A\nETH=000D0\nEacute=000C9\nEcaron=0011A\nEcirc=000CA\nEcy=0042D\nEdot=00116\nEfr=1D508\nEgrave=000C8\nElement=02208\nEmacr=00112\nEmptySmallSquare=025FB\nEmptyVerySmallSquare=025AB\nEogon=00118\nEopf=1D53C\nEpsilon=00395\nEqual=02A75\nEqualTilde=02242\nEquilibrium=021CC\nEscr=02130\nEsim=02A73\nEta=00397\nEuml=000CB\nExists=02203\nExponentialE=02147\nFcy=00424\nFfr=1D509\nFilledSmallSquare=025FC\nFilledVerySmallSquare=025AA\nFopf=1D53D\nForAll=02200\nFouriertrf=02131\nFscr=02131\nGJcy=00403\nGT=0003E\nGamma=00393\nGammad=003DC\nGbreve=0011E\nGcedil=00122\nGcirc=0011C\nGcy=00413\nGdot=00120\nGfr=1D50A\nGg=022D9\nGopf=1D53E\nGreaterEqual=02265\nGreaterEqualLess=022DB\nGreaterFullEqual=02267\nGreaterGreater=02AA2\nGreaterLess=02277\nGreaterSlantEqual=02A7E\nGreaterTilde=02273\nGscr=1D4A2\nGt=0226B\nHARDcy=0042A\nHacek=002C7\nHat=0005E\nHcirc=00124\nHfr=0210C\nHilbertSpace=0210B\nHopf=0210D\nHorizontalLine=02500\nHscr=0210B\nHstrok=00126\nHumpDownHump=0224E\nHumpEqual=0224F\nIEcy=00415\nIJlig=00132\nIOcy=00401\nIacute=000CD\nIcirc=000CE\nIcy=00418\nIdot=00130\nIfr=02111\nIgrave=000CC\nIm=02111\nImacr=0012A\nImaginaryI=02148\nImplies=021D2\nInt=0222C\nIntegral=0222B\nIntersection=022C2\nInvisibleComma=02063\nInvisibleTimes=02062\nIogon=0012E\nIopf=1D540\nIota=00399\nIscr=02110\nItilde=00128\nIukcy=00406\nIuml=000CF\nJcirc=00134\nJcy=00419\nJfr=1D50D\nJopf=1D541\nJscr=1D4A5\nJsercy=00408\nJukcy=00404\nKHcy=00425\nKJcy=0040C\nKappa=0039A\nKcedil=00136\nKcy=0041A\nKfr=1D50E\nKopf=1D542\nKscr=1D4A6\nLJcy=00409\nLT=0003C\nLacute=00139\nLambda=0039B\nLang=027EA\nLaplacetrf=02112\nLarr=0219E\nLcaron=0013D\nLcedil=0013B\nLcy=0041B\nLeftAngleBracket=027E8\nLeftArrow=02190\nLeftArrowBar=021E4\nLeftArrowRightArrow=021C6\nLeftCeiling=02308\nLeftDoubleBracket=027E6\nLeftDownTeeVector=02961\nLeftDownVector=021C3\nLeftDownVectorBar=02959\nLeftFloor=0230A\nLeftRightArrow=02194\nLeftRightVector=0294E\nLeftTee=022A3\nLeftTeeArrow=021A4\nLeftTeeVector=0295A\nLeftTriangle=022B2\nLeftTriangleBar=029CF\nLeftTriangleEqual=022B4\nLeftUpDownVector=02951\nLeftUpTeeVector=02960\nLeftUpVector=021BF\nLeftUpVectorBar=02958\nLeftVector=021BC\nLeftVectorBar=02952\nLeftarrow=021D0\nLeftrightarrow=021D4\nLessEqualGreater=022DA\nLessFullEqual=02266\nLessGreater=02276\nLessLess=02AA1\nLessSlantEqual=02A7D\nLessTilde=02272\nLfr=1D50F\nLl=022D8\nLleftarrow=021DA\nLmidot=0013F\nLongLeftArrow=027F5\nLongLeftRightArrow=027F7\nLongRightArrow=027F6\nLongleftarrow=027F8\nLongleftrightarrow=027FA\nLongrightarrow=027F9\nLopf=1D543\nLowerLeftArrow=02199\nLowerRightArrow=02198\nLscr=02112\nLsh=021B0\nLstrok=00141\nLt=0226A\nMap=02905\nMcy=0041C\nMediumSpace=0205F\nMellintrf=02133\nMfr=1D510\nMinusPlus=02213\nMopf=1D544\nMscr=02133\nMu=0039C\nNJcy=0040A\nNacute=00143\nNcaron=00147\nNcedil=00145\nNcy=0041D\nNegativeMediumSpace=0200B\nNegativeThickSpace=0200B\nNegativeThinSpace=0200B\nNegativeVeryThinSpace=0200B\nNestedGreaterGreater=0226B\nNestedLessLess=0226A\nNewLine=0000A\nNfr=1D511\nNoBreak=02060\nNonBreakingSpace=000A0\nNopf=02115\nNot=02AEC\nNotCongruent=02262\nNotCupCap=0226D\nNotDoubleVerticalBar=02226\nNotElement=02209\nNotEqual=02260\nNotExists=02204\nNotGreater=0226F\nNotGreaterEqual=02271\nNotGreaterLess=02279\nNotGreaterTilde=02275\nNotLeftTriangle=022EA\nNotLeftTriangleEqual=022EC\nNotLess=0226E\nNotLessEqual=02270\nNotLessGreater=02278\nNotLessTilde=02274\nNotPrecedes=02280\nNotPrecedesSlantEqual=022E0\nNotReverseElement=0220C\nNotRightTriangle=022EB\nNotRightTriangleEqual=022ED\nNotSquareSubsetEqual=022E2\nNotSquareSupersetEqual=022E3\nNotSubsetEqual=02288\nNotSucceeds=02281\nNotSucceedsSlantEqual=022E1\nNotSupersetEqual=02289\nNotTilde=02241\nNotTildeEqual=02244\nNotTildeFullEqual=02247\nNotTildeTilde=02249\nNotVerticalBar=02224\nNscr=1D4A9\nNtilde=000D1\nNu=0039D\nOElig=00152\nOacute=000D3\nOcirc=000D4\nOcy=0041E\nOdblac=00150\nOfr=1D512\nOgrave=000D2\nOmacr=0014C\nOmega=003A9\nOmicron=0039F\nOopf=1D546\nOpenCurlyDoubleQuote=0201C\nOpenCurlyQuote=02018\nOr=02A54\nOscr=1D4AA\nOslash=000D8\nOtilde=000D5\nOtimes=02A37\nOuml=000D6\nOverBar=0203E\nOverBrace=023DE\nOverBracket=023B4\nOverParenthesis=023DC\nPartialD=02202\nPcy=0041F\nPfr=1D513\nPhi=003A6\nPi=003A0\nPlusMinus=000B1\nPoincareplane=0210C\nPopf=02119\nPr=02ABB\nPrecedes=0227A\nPrecedesEqual=02AAF\nPrecedesSlantEqual=0227C\nPrecedesTilde=0227E\nPrime=02033\nProduct=0220F\nProportion=02237\nProportional=0221D\nPscr=1D4AB\nPsi=003A8\nQUOT=00022\nQfr=1D514\nQopf=0211A\nQscr=1D4AC\nRBarr=02910\nREG=000AE\nRacute=00154\nRang=027EB\nRarr=021A0\nRarrtl=02916\nRcaron=00158\nRcedil=00156\nRcy=00420\nRe=0211C\nReverseElement=0220B\nReverseEquilibrium=021CB\nReverseUpEquilibrium=0296F\nRfr=0211C\nRho=003A1\nRightAngleBracket=027E9\nRightArrow=02192\nRightArrowBar=021E5\nRightArrowLeftArrow=021C4\nRightCeiling=02309\nRightDoubleBracket=027E7\nRightDownTeeVector=0295D\nRightDownVector=021C2\nRightDownVectorBar=02955\nRightFloor=0230B\nRightTee=022A2\nRightTeeArrow=021A6\nRightTeeVector=0295B\nRightTriangle=022B3\nRightTriangleBar=029D0\nRightTriangleEqual=022B5\nRightUpDownVector=0294F\nRightUpTeeVector=0295C\nRightUpVector=021BE\nRightUpVectorBar=02954\nRightVector=021C0\nRightVectorBar=02953\nRightarrow=021D2\nRopf=0211D\nRoundImplies=02970\nRrightarrow=021DB\nRscr=0211B\nRsh=021B1\nRuleDelayed=029F4\nSHCHcy=00429\nSHcy=00428\nSOFTcy=0042C\nSacute=0015A\nSc=02ABC\nScaron=00160\nScedil=0015E\nScirc=0015C\nScy=00421\nSfr=1D516\nShortDownArrow=02193\nShortLeftArrow=02190\nShortRightArrow=02192\nShortUpArrow=02191\nSigma=003A3\nSmallCircle=02218\nSopf=1D54A\nSqrt=0221A\nSquare=025A1\nSquareIntersection=02293\nSquareSubset=0228F\nSquareSubsetEqual=02291\nSquareSuperset=02290\nSquareSupersetEqual=02292\nSquareUnion=02294\nSscr=1D4AE\nStar=022C6\nSub=022D0\nSubset=022D0\nSubsetEqual=02286\nSucceeds=0227B\nSucceedsEqual=02AB0\nSucceedsSlantEqual=0227D\nSucceedsTilde=0227F\nSuchThat=0220B\nSum=02211\nSup=022D1\nSuperset=02283\nSupersetEqual=02287\nSupset=022D1\nTHORN=000DE\nTRADE=02122\nTSHcy=0040B\nTScy=00426\nTab=00009\nTau=003A4\nTcaron=00164\nTcedil=00162\nTcy=00422\nTfr=1D517\nTherefore=02234\nTheta=00398\nThinSpace=02009\nTilde=0223C\nTildeEqual=02243\nTildeFullEqual=02245\nTildeTilde=02248\nTopf=1D54B\nTripleDot=020DB\nTscr=1D4AF\nTstrok=00166\nUacute=000DA\nUarr=0219F\nUarrocir=02949\nUbrcy=0040E\nUbreve=0016C\nUcirc=000DB\nUcy=00423\nUdblac=00170\nUfr=1D518\nUgrave=000D9\nUmacr=0016A\nUnderBar=0005F\nUnderBrace=023DF\nUnderBracket=023B5\nUnderParenthesis=023DD\nUnion=022C3\nUnionPlus=0228E\nUogon=00172\nUopf=1D54C\nUpArrow=02191\nUpArrowBar=02912\nUpArrowDownArrow=021C5\nUpDownArrow=02195\nUpEquilibrium=0296E\nUpTee=022A5\nUpTeeArrow=021A5\nUparrow=021D1\nUpdownarrow=021D5\nUpperLeftArrow=02196\nUpperRightArrow=02197\nUpsi=003D2\nUpsilon=003A5\nUring=0016E\nUscr=1D4B0\nUtilde=00168\nUuml=000DC\nVDash=022AB\nVbar=02AEB\nVcy=00412\nVdash=022A9\nVdashl=02AE6\nVee=022C1\nVerbar=02016\nVert=02016\nVerticalBar=02223\nVerticalLine=0007C\nVerticalSeparator=02758\nVerticalTilde=02240\nVeryThinSpace=0200A\nVfr=1D519\nVopf=1D54D\nVscr=1D4B1\nVvdash=022AA\nWcirc=00174\nWedge=022C0\nWfr=1D51A\nWopf=1D54E\nWscr=1D4B2\nXfr=1D51B\nXi=0039E\nXopf=1D54F\nXscr=1D4B3\nYAcy=0042F\nYIcy=00407\nYUcy=0042E\nYacute=000DD\nYcirc=00176\nYcy=0042B\nYfr=1D51C\nYopf=1D550\nYscr=1D4B4\nYuml=00178\nZHcy=00416\nZacute=00179\nZcaron=0017D\nZcy=00417\nZdot=0017B\nZeroWidthSpace=0200B\nZeta=00396\nZfr=02128\nZopf=02124\nZscr=1D4B5\naacute=000E1\nabreve=00103\nac=0223E\nacd=0223F\nacirc=000E2\nacute=000B4\nacy=00430\naelig=000E6\naf=02061\nafr=1D51E\nagrave=000E0\nalefsym=02135\naleph=02135\nalpha=003B1\namacr=00101\namalg=02A3F\namp=00026\nand=02227\nandand=02A55\nandd=02A5C\nandslope=02A58\nandv=02A5A\nang=02220\nange=029A4\nangle=02220\nangmsd=02221\nangmsdaa=029A8\nangmsdab=029A9\nangmsdac=029AA\nangmsdad=029AB\nangmsdae=029AC\nangmsdaf=029AD\nangmsdag=029AE\nangmsdah=029AF\nangrt=0221F\nangrtvb=022BE\nangrtvbd=0299D\nangsph=02222\nangst=000C5\nangzarr=0237C\naogon=00105\naopf=1D552\nap=02248\napE=02A70\napacir=02A6F\nape=0224A\napid=0224B\napos=00027\napprox=02248\napproxeq=0224A\naring=000E5\nascr=1D4B6\nast=0002A\nasymp=02248\nasympeq=0224D\natilde=000E3\nauml=000E4\nawconint=02233\nawint=02A11\nbNot=02AED\nbackcong=0224C\nbackepsilon=003F6\nbackprime=02035\nbacksim=0223D\nbacksimeq=022CD\nbarvee=022BD\nbarwed=02305\nbarwedge=02305\nbbrk=023B5\nbbrktbrk=023B6\nbcong=0224C\nbcy=00431\nbdquo=0201E\nbecaus=02235\nbecause=02235\nbemptyv=029B0\nbepsi=003F6\nbernou=0212C\nbeta=003B2\nbeth=02136\nbetween=0226C\nbfr=1D51F\nbigcap=022C2\nbigcirc=025EF\nbigcup=022C3\nbigodot=02A00\nbigoplus=02A01\nbigotimes=02A02\nbigsqcup=02A06\nbigstar=02605\nbigtriangledown=025BD\nbigtriangleup=025B3\nbiguplus=02A04\nbigvee=022C1\nbigwedge=022C0\nbkarow=0290D\nblacklozenge=029EB\nblacksquare=025AA\nblacktriangle=025B4\nblacktriangledown=025BE\nblacktriangleleft=025C2\nblacktriangleright=025B8\nblank=02423\nblk12=02592\nblk14=02591\nblk34=02593\nblock=02588\nbnot=02310\nbopf=1D553\nbot=022A5\nbottom=022A5\nbowtie=022C8\nboxDL=02557\nboxDR=02554\nboxDl=02556\nboxDr=02553\nboxH=02550\nboxHD=02566\nboxHU=02569\nboxHd=02564\nboxHu=02567\nboxUL=0255D\nboxUR=0255A\nboxUl=0255C\nboxUr=02559\nboxV=02551\nboxVH=0256C\nboxVL=02563\nboxVR=02560\nboxVh=0256B\nboxVl=02562\nboxVr=0255F\nboxbox=029C9\nboxdL=02555\nboxdR=02552\nboxdl=02510\nboxdr=0250C\nboxh=02500\nboxhD=02565\nboxhU=02568\nboxhd=0252C\nboxhu=02534\nboxminus=0229F\nboxplus=0229E\nboxtimes=022A0\nboxuL=0255B\nboxuR=02558\nboxul=02518\nboxur=02514\nboxv=02502\nboxvH=0256A\nboxvL=02561\nboxvR=0255E\nboxvh=0253C\nboxvl=02524\nboxvr=0251C\nbprime=02035\nbreve=002D8\nbrvbar=000A6\nbscr=1D4B7\nbsemi=0204F\nbsim=0223D\nbsime=022CD\nbsol=0005C\nbsolb=029C5\nbsolhsub=027C8\nbull=02022\nbullet=02022\nbump=0224E\nbumpE=02AAE\nbumpe=0224F\nbumpeq=0224F\ncacute=00107\ncap=02229\ncapand=02A44\ncapbrcup=02A49\ncapcap=02A4B\ncapcup=02A47\ncapdot=02A40\ncaret=02041\ncaron=002C7\nccaps=02A4D\nccaron=0010D\nccedil=000E7\nccirc=00109\nccups=02A4C\nccupssm=02A50\ncdot=0010B\ncedil=000B8\ncemptyv=029B2\ncent=000A2\ncenterdot=000B7\ncfr=1D520\nchcy=00447\ncheck=02713\ncheckmark=02713\nchi=003C7\ncir=025CB\ncirE=029C3\ncirc=002C6\ncirceq=02257\ncirclearrowleft=021BA\ncirclearrowright=021BB\ncircledR=000AE\ncircledS=024C8\ncircledast=0229B\ncircledcirc=0229A\ncircleddash=0229D\ncire=02257\ncirfnint=02A10\ncirmid=02AEF\ncirscir=029C2\nclubs=02663\nclubsuit=02663\ncolon=0003A\ncolone=02254\ncoloneq=02254\ncomma=0002C\ncommat=00040\ncomp=02201\ncompfn=02218\ncomplement=02201\ncomplexes=02102\ncong=02245\ncongdot=02A6D\nconint=0222E\ncopf=1D554\ncoprod=02210\ncopy=000A9\ncopysr=02117\ncrarr=021B5\ncross=02717\ncscr=1D4B8\ncsub=02ACF\ncsube=02AD1\ncsup=02AD0\ncsupe=02AD2\nctdot=022EF\ncudarrl=02938\ncudarrr=02935\ncuepr=022DE\ncuesc=022DF\ncularr=021B6\ncularrp=0293D\ncup=0222A\ncupbrcap=02A48\ncupcap=02A46\ncupcup=02A4A\ncupdot=0228D\ncupor=02A45\ncurarr=021B7\ncurarrm=0293C\ncurlyeqprec=022DE\ncurlyeqsucc=022DF\ncurlyvee=022CE\ncurlywedge=022CF\ncurren=000A4\ncurvearrowleft=021B6\ncurvearrowright=021B7\ncuvee=022CE\ncuwed=022CF\ncwconint=02232\ncwint=02231\ncylcty=0232D\ndArr=021D3\ndHar=02965\ndagger=02020\ndaleth=02138\ndarr=02193\ndash=02010\ndashv=022A3\ndbkarow=0290F\ndblac=002DD\ndcaron=0010F\ndcy=00434\ndd=02146\nddagger=02021\nddarr=021CA\nddotseq=02A77\ndeg=000B0\ndelta=003B4\ndemptyv=029B1\ndfisht=0297F\ndfr=1D521\ndharl=021C3\ndharr=021C2\ndiam=022C4\ndiamond=022C4\ndiamondsuit=02666\ndiams=02666\ndie=000A8\ndigamma=003DD\ndisin=022F2\ndiv=000F7\ndivide=000F7\ndivideontimes=022C7\ndivonx=022C7\ndjcy=00452\ndlcorn=0231E\ndlcrop=0230D\ndollar=00024\ndopf=1D555\ndot=002D9\ndoteq=02250\ndoteqdot=02251\ndotminus=02238\ndotplus=02214\ndotsquare=022A1\ndoublebarwedge=02306\ndownarrow=02193\ndowndownarrows=021CA\ndownharpoonleft=021C3\ndownharpoonright=021C2\ndrbkarow=02910\ndrcorn=0231F\ndrcrop=0230C\ndscr=1D4B9\ndscy=00455\ndsol=029F6\ndstrok=00111\ndtdot=022F1\ndtri=025BF\ndtrif=025BE\nduarr=021F5\nduhar=0296F\ndwangle=029A6\ndzcy=0045F\ndzigrarr=027FF\neDDot=02A77\neDot=02251\neacute=000E9\neaster=02A6E\necaron=0011B\necir=02256\necirc=000EA\necolon=02255\necy=0044D\nedot=00117\nee=02147\nefDot=02252\nefr=1D522\neg=02A9A\negrave=000E8\negs=02A96\negsdot=02A98\nel=02A99\nelinters=023E7\nell=02113\nels=02A95\nelsdot=02A97\nemacr=00113\nempty=02205\nemptyset=02205\nemptyv=02205\nemsp13=02004\nemsp14=02005\nemsp=02003\neng=0014B\nensp=02002\neogon=00119\neopf=1D556\nepar=022D5\neparsl=029E3\neplus=02A71\nepsi=003B5\nepsilon=003B5\nepsiv=003F5\neqcirc=02256\neqcolon=02255\neqsim=02242\neqslantgtr=02A96\neqslantless=02A95\nequals=0003D\nequest=0225F\nequiv=02261\nequivDD=02A78\neqvparsl=029E5\nerDot=02253\nerarr=02971\nescr=0212F\nesdot=02250\nesim=02242\neta=003B7\neth=000F0\neuml=000EB\neuro=020AC\nexcl=00021\nexist=02203\nexpectation=02130\nexponentiale=02147\nfallingdotseq=02252\nfcy=00444\nfemale=02640\nffilig=0FB03\nfflig=0FB00\nffllig=0FB04\nffr=1D523\nfilig=0FB01\nflat=0266D\nfllig=0FB02\nfltns=025B1\nfnof=00192\nfopf=1D557\nforall=02200\nfork=022D4\nforkv=02AD9\nfpartint=02A0D\nfrac12=000BD\nfrac13=02153\nfrac14=000BC\nfrac15=02155\nfrac16=02159\nfrac18=0215B\nfrac23=02154\nfrac25=02156\nfrac34=000BE\nfrac35=02157\nfrac38=0215C\nfrac45=02158\nfrac56=0215A\nfrac58=0215D\nfrac78=0215E\nfrasl=02044\nfrown=02322\nfscr=1D4BB\ngE=02267\ngEl=02A8C\ngacute=001F5\ngamma=003B3\ngammad=003DD\ngap=02A86\ngbreve=0011F\ngcirc=0011D\ngcy=00433\ngdot=00121\nge=02265\ngel=022DB\ngeq=02265\ngeqq=02267\ngeqslant=02A7E\nges=02A7E\ngescc=02AA9\ngesdot=02A80\ngesdoto=02A82\ngesdotol=02A84\ngesles=02A94\ngfr=1D524\ngg=0226B\nggg=022D9\ngimel=02137\ngjcy=00453\ngl=02277\nglE=02A92\ngla=02AA5\nglj=02AA4\ngnE=02269\ngnap=02A8A\ngnapprox=02A8A\ngne=02A88\ngneq=02A88\ngneqq=02269\ngnsim=022E7\ngopf=1D558\ngrave=00060\ngscr=0210A\ngsim=02273\ngsime=02A8E\ngsiml=02A90\ngt=0003E\ngtcc=02AA7\ngtcir=02A7A\ngtdot=022D7\ngtlPar=02995\ngtquest=02A7C\ngtrapprox=02A86\ngtrarr=02978\ngtrdot=022D7\ngtreqless=022DB\ngtreqqless=02A8C\ngtrless=02277\ngtrsim=02273\nhArr=021D4\nhairsp=0200A\nhalf=000BD\nhamilt=0210B\nhardcy=0044A\nharr=02194\nharrcir=02948\nharrw=021AD\nhbar=0210F\nhcirc=00125\nhearts=02665\nheartsuit=02665\nhellip=02026\nhercon=022B9\nhfr=1D525\nhksearow=02925\nhkswarow=02926\nhoarr=021FF\nhomtht=0223B\nhookleftarrow=021A9\nhookrightarrow=021AA\nhopf=1D559\nhorbar=02015\nhscr=1D4BD\nhslash=0210F\nhstrok=00127\nhybull=02043\nhyphen=02010\niacute=000ED\nic=02063\nicirc=000EE\nicy=00438\niecy=00435\niexcl=000A1\niff=021D4\nifr=1D526\nigrave=000EC\nii=02148\niiiint=02A0C\niiint=0222D\niinfin=029DC\niiota=02129\nijlig=00133\nimacr=0012B\nimage=02111\nimagline=02110\nimagpart=02111\nimath=00131\nimof=022B7\nimped=001B5\nin=02208\nincare=02105\ninfin=0221E\ninfintie=029DD\ninodot=00131\nint=0222B\nintcal=022BA\nintegers=02124\nintercal=022BA\nintlarhk=02A17\nintprod=02A3C\niocy=00451\niogon=0012F\niopf=1D55A\niota=003B9\niprod=02A3C\niquest=000BF\niscr=1D4BE\nisin=02208\nisinE=022F9\nisindot=022F5\nisins=022F4\nisinsv=022F3\nisinv=02208\nit=02062\nitilde=00129\niukcy=00456\niuml=000EF\njcirc=00135\njcy=00439\njfr=1D527\njmath=00237\njopf=1D55B\njscr=1D4BF\njsercy=00458\njukcy=00454\nkappa=003BA\nkappav=003F0\nkcedil=00137\nkcy=0043A\nkfr=1D528\nkgreen=00138\nkhcy=00445\nkjcy=0045C\nkopf=1D55C\nkscr=1D4C0\nlAarr=021DA\nlArr=021D0\nlAtail=0291B\nlBarr=0290E\nlE=02266\nlEg=02A8B\nlHar=02962\nlacute=0013A\nlaemptyv=029B4\nlagran=02112\nlambda=003BB\nlang=027E8\nlangd=02991\nlangle=027E8\nlap=02A85\nlaquo=000AB\nlarr=02190\nlarrb=021E4\nlarrbfs=0291F\nlarrfs=0291D\nlarrhk=021A9\nlarrlp=021AB\nlarrpl=02939\nlarrsim=02973\nlarrtl=021A2\nlat=02AAB\nlatail=02919\nlate=02AAD\nlbarr=0290C\nlbbrk=02772\nlbrace=0007B\nlbrack=0005B\nlbrke=0298B\nlbrksld=0298F\nlbrkslu=0298D\nlcaron=0013E\nlcedil=0013C\nlceil=02308\nlcub=0007B\nlcy=0043B\nldca=02936\nldquo=0201C\nldquor=0201E\nldrdhar=02967\nldrushar=0294B\nldsh=021B2\nle=02264\nleftarrow=02190\nleftarrowtail=021A2\nleftharpoondown=021BD\nleftharpoonup=021BC\nleftleftarrows=021C7\nleftrightarrow=02194\nleftrightarrows=021C6\nleftrightharpoons=021CB\nleftrightsquigarrow=021AD\nleftthreetimes=022CB\nleg=022DA\nleq=02264\nleqq=02266\nleqslant=02A7D\nles=02A7D\nlescc=02AA8\nlesdot=02A7F\nlesdoto=02A81\nlesdotor=02A83\nlesges=02A93\nlessapprox=02A85\nlessdot=022D6\nlesseqgtr=022DA\nlesseqqgtr=02A8B\nlessgtr=02276\nlesssim=02272\nlfisht=0297C\nlfloor=0230A\nlfr=1D529\nlg=02276\nlgE=02A91\nlhard=021BD\nlharu=021BC\nlharul=0296A\nlhblk=02584\nljcy=00459\nll=0226A\nllarr=021C7\nllcorner=0231E\nllhard=0296B\nlltri=025FA\nlmidot=00140\nlmoust=023B0\nlmoustache=023B0\nlnE=02268\nlnap=02A89\nlnapprox=02A89\nlne=02A87\nlneq=02A87\nlneqq=02268\nlnsim=022E6\nloang=027EC\nloarr=021FD\nlobrk=027E6\nlongleftarrow=027F5\nlongleftrightarrow=027F7\nlongmapsto=027FC\nlongrightarrow=027F6\nlooparrowleft=021AB\nlooparrowright=021AC\nlopar=02985\nlopf=1D55D\nloplus=02A2D\nlotimes=02A34\nlowast=02217\nlowbar=0005F\nloz=025CA\nlozenge=025CA\nlozf=029EB\nlpar=00028\nlparlt=02993\nlrarr=021C6\nlrcorner=0231F\nlrhar=021CB\nlrhard=0296D\nlrm=0200E\nlrtri=022BF\nlsaquo=02039\nlscr=1D4C1\nlsh=021B0\nlsim=02272\nlsime=02A8D\nlsimg=02A8F\nlsqb=0005B\nlsquo=02018\nlsquor=0201A\nlstrok=00142\nlt=0003C\nltcc=02AA6\nltcir=02A79\nltdot=022D6\nlthree=022CB\nltimes=022C9\nltlarr=02976\nltquest=02A7B\nltrPar=02996\nltri=025C3\nltrie=022B4\nltrif=025C2\nlurdshar=0294A\nluruhar=02966\nmDDot=0223A\nmacr=000AF\nmale=02642\nmalt=02720\nmaltese=02720\nmap=021A6\nmapsto=021A6\nmapstodown=021A7\nmapstoleft=021A4\nmapstoup=021A5\nmarker=025AE\nmcomma=02A29\nmcy=0043C\nmdash=02014\nmeasuredangle=02221\nmfr=1D52A\nmho=02127\nmicro=000B5\nmid=02223\nmidast=0002A\nmidcir=02AF0\nmiddot=000B7\nminus=02212\nminusb=0229F\nminusd=02238\nminusdu=02A2A\nmlcp=02ADB\nmldr=02026\nmnplus=02213\nmodels=022A7\nmopf=1D55E\nmp=02213\nmscr=1D4C2\nmstpos=0223E\nmu=003BC\nmultimap=022B8\nmumap=022B8\nnLeftarrow=021CD\nnLeftrightarrow=021CE\nnRightarrow=021CF\nnVDash=022AF\nnVdash=022AE\nnabla=02207\nnacute=00144\nnap=02249\nnapos=00149\nnapprox=02249\nnatur=0266E\nnatural=0266E\nnaturals=02115\nnbsp=000A0\nncap=02A43\nncaron=00148\nncedil=00146\nncong=02247\nncup=02A42\nncy=0043D\nndash=02013\nne=02260\nneArr=021D7\nnearhk=02924\nnearr=02197\nnearrow=02197\nnequiv=02262\nnesear=02928\nnexist=02204\nnexists=02204\nnfr=1D52B\nnge=02271\nngeq=02271\nngsim=02275\nngt=0226F\nngtr=0226F\nnhArr=021CE\nnharr=021AE\nnhpar=02AF2\nni=0220B\nnis=022FC\nnisd=022FA\nniv=0220B\nnjcy=0045A\nnlArr=021CD\nnlarr=0219A\nnldr=02025\nnle=02270\nnleftarrow=0219A\nnleftrightarrow=021AE\nnleq=02270\nnless=0226E\nnlsim=02274\nnlt=0226E\nnltri=022EA\nnltrie=022EC\nnmid=02224\nnopf=1D55F\nnot=000AC\nnotin=02209\nnotinva=02209\nnotinvb=022F7\nnotinvc=022F6\nnotni=0220C\nnotniva=0220C\nnotnivb=022FE\nnotnivc=022FD\nnpar=02226\nnparallel=02226\nnpolint=02A14\nnpr=02280\nnprcue=022E0\nnprec=02280\nnrArr=021CF\nnrarr=0219B\nnrightarrow=0219B\nnrtri=022EB\nnrtrie=022ED\nnsc=02281\nnsccue=022E1\nnscr=1D4C3\nnshortmid=02224\nnshortparallel=02226\nnsim=02241\nnsime=02244\nnsimeq=02244\nnsmid=02224\nnspar=02226\nnsqsube=022E2\nnsqsupe=022E3\nnsub=02284\nnsube=02288\nnsubseteq=02288\nnsucc=02281\nnsup=02285\nnsupe=02289\nnsupseteq=02289\nntgl=02279\nntilde=000F1\nntlg=02278\nntriangleleft=022EA\nntrianglelefteq=022EC\nntriangleright=022EB\nntrianglerighteq=022ED\nnu=003BD\nnum=00023\nnumero=02116\nnumsp=02007\nnvDash=022AD\nnvHarr=02904\nnvdash=022AC\nnvinfin=029DE\nnvlArr=02902\nnvrArr=02903\nnwArr=021D6\nnwarhk=02923\nnwarr=02196\nnwarrow=02196\nnwnear=02927\noS=024C8\noacute=000F3\noast=0229B\nocir=0229A\nocirc=000F4\nocy=0043E\nodash=0229D\nodblac=00151\nodiv=02A38\nodot=02299\nodsold=029BC\noelig=00153\nofcir=029BF\nofr=1D52C\nogon=002DB\nograve=000F2\nogt=029C1\nohbar=029B5\nohm=003A9\noint=0222E\nolarr=021BA\nolcir=029BE\nolcross=029BB\noline=0203E\nolt=029C0\nomacr=0014D\nomega=003C9\nomicron=003BF\nomid=029B6\nominus=02296\noopf=1D560\nopar=029B7\noperp=029B9\noplus=02295\nor=02228\norarr=021BB\nord=02A5D\norder=02134\norderof=02134\nordf=000AA\nordm=000BA\norigof=022B6\noror=02A56\norslope=02A57\norv=02A5B\noscr=02134\noslash=000F8\nosol=02298\notilde=000F5\notimes=02297\notimesas=02A36\nouml=000F6\novbar=0233D\npar=02225\npara=000B6\nparallel=02225\nparsim=02AF3\nparsl=02AFD\npart=02202\npcy=0043F\npercnt=00025\nperiod=0002E\npermil=02030\nperp=022A5\npertenk=02031\npfr=1D52D\nphi=003C6\nphiv=003D5\nphmmat=02133\nphone=0260E\npi=003C0\npitchfork=022D4\npiv=003D6\nplanck=0210F\nplanckh=0210E\nplankv=0210F\nplus=0002B\nplusacir=02A23\nplusb=0229E\npluscir=02A22\nplusdo=02214\nplusdu=02A25\npluse=02A72\nplusmn=000B1\nplussim=02A26\nplustwo=02A27\npm=000B1\npointint=02A15\npopf=1D561\npound=000A3\npr=0227A\nprE=02AB3\nprap=02AB7\nprcue=0227C\npre=02AAF\nprec=0227A\nprecapprox=02AB7\npreccurlyeq=0227C\npreceq=02AAF\nprecnapprox=02AB9\nprecneqq=02AB5\nprecnsim=022E8\nprecsim=0227E\nprime=02032\nprimes=02119\nprnE=02AB5\nprnap=02AB9\nprnsim=022E8\nprod=0220F\nprofalar=0232E\nprofline=02312\nprofsurf=02313\nprop=0221D\npropto=0221D\nprsim=0227E\nprurel=022B0\npscr=1D4C5\npsi=003C8\npuncsp=02008\nqfr=1D52E\nqint=02A0C\nqopf=1D562\nqprime=02057\nqscr=1D4C6\nquaternions=0210D\nquatint=02A16\nquest=0003F\nquesteq=0225F\nquot=00022\nrAarr=021DB\nrArr=021D2\nrAtail=0291C\nrBarr=0290F\nrHar=02964\nracute=00155\nradic=0221A\nraemptyv=029B3\nrang=027E9\nrangd=02992\nrange=029A5\nrangle=027E9\nraquo=000BB\nrarr=02192\nrarrap=02975\nrarrb=021E5\nrarrbfs=02920\nrarrc=02933\nrarrfs=0291E\nrarrhk=021AA\nrarrlp=021AC\nrarrpl=02945\nrarrsim=02974\nrarrtl=021A3\nrarrw=0219D\nratail=0291A\nratio=02236\nrationals=0211A\nrbarr=0290D\nrbbrk=02773\nrbrace=0007D\nrbrack=0005D\nrbrke=0298C\nrbrksld=0298E\nrbrkslu=02990\nrcaron=00159\nrcedil=00157\nrceil=02309\nrcub=0007D\nrcy=00440\nrdca=02937\nrdldhar=02969\nrdquo=0201D\nrdquor=0201D\nrdsh=021B3\nreal=0211C\nrealine=0211B\nrealpart=0211C\nreals=0211D\nrect=025AD\nreg=000AE\nrfisht=0297D\nrfloor=0230B\nrfr=1D52F\nrhard=021C1\nrharu=021C0\nrharul=0296C\nrho=003C1\nrhov=003F1\nrightarrow=02192\nrightarrowtail=021A3\nrightharpoondown=021C1\nrightharpoonup=021C0\nrightleftarrows=021C4\nrightleftharpoons=021CC\nrightrightarrows=021C9\nrightsquigarrow=0219D\nrightthreetimes=022CC\nring=002DA\nrisingdotseq=02253\nrlarr=021C4\nrlhar=021CC\nrlm=0200F\nrmoust=023B1\nrmoustache=023B1\nrnmid=02AEE\nroang=027ED\nroarr=021FE\nrobrk=027E7\nropar=02986\nropf=1D563\nroplus=02A2E\nrotimes=02A35\nrpar=00029\nrpargt=02994\nrppolint=02A12\nrrarr=021C9\nrsaquo=0203A\nrscr=1D4C7\nrsh=021B1\nrsqb=0005D\nrsquo=02019\nrsquor=02019\nrthree=022CC\nrtimes=022CA\nrtri=025B9\nrtrie=022B5\nrtrif=025B8\nrtriltri=029CE\nruluhar=02968\nrx=0211E\nsacute=0015B\nsbquo=0201A\nsc=0227B\nscE=02AB4\nscap=02AB8\nscaron=00161\nsccue=0227D\nsce=02AB0\nscedil=0015F\nscirc=0015D\nscnE=02AB6\nscnap=02ABA\nscnsim=022E9\nscpolint=02A13\nscsim=0227F\nscy=00441\nsdot=022C5\nsdotb=022A1\nsdote=02A66\nseArr=021D8\nsearhk=02925\nsearr=02198\nsearrow=02198\nsect=000A7\nsemi=0003B\nseswar=02929\nsetminus=02216\nsetmn=02216\nsext=02736\nsfr=1D530\nsfrown=02322\nsharp=0266F\nshchcy=00449\nshcy=00448\nshortmid=02223\nshortparallel=02225\nshy=000AD\nsigma=003C3\nsigmaf=003C2\nsigmav=003C2\nsim=0223C\nsimdot=02A6A\nsime=02243\nsimeq=02243\nsimg=02A9E\nsimgE=02AA0\nsiml=02A9D\nsimlE=02A9F\nsimne=02246\nsimplus=02A24\nsimrarr=02972\nslarr=02190\nsmallsetminus=02216\nsmashp=02A33\nsmeparsl=029E4\nsmid=02223\nsmile=02323\nsmt=02AAA\nsmte=02AAC\nsoftcy=0044C\nsol=0002F\nsolb=029C4\nsolbar=0233F\nsopf=1D564\nspades=02660\nspadesuit=02660\nspar=02225\nsqcap=02293\nsqcup=02294\nsqsub=0228F\nsqsube=02291\nsqsubset=0228F\nsqsubseteq=02291\nsqsup=02290\nsqsupe=02292\nsqsupset=02290\nsqsupseteq=02292\nsqu=025A1\nsquare=025A1\nsquarf=025AA\nsquf=025AA\nsrarr=02192\nsscr=1D4C8\nssetmn=02216\nssmile=02323\nsstarf=022C6\nstar=02606\nstarf=02605\nstraightepsilon=003F5\nstraightphi=003D5\nstrns=000AF\nsub=02282\nsubE=02AC5\nsubdot=02ABD\nsube=02286\nsubedot=02AC3\nsubmult=02AC1\nsubnE=02ACB\nsubne=0228A\nsubplus=02ABF\nsubrarr=02979\nsubset=02282\nsubseteq=02286\nsubseteqq=02AC5\nsubsetneq=0228A\nsubsetneqq=02ACB\nsubsim=02AC7\nsubsub=02AD5\nsubsup=02AD3\nsucc=0227B\nsuccapprox=02AB8\nsucccurlyeq=0227D\nsucceq=02AB0\nsuccnapprox=02ABA\nsuccneqq=02AB6\nsuccnsim=022E9\nsuccsim=0227F\nsum=02211\nsung=0266A\nsup1=000B9\nsup2=000B2\nsup3=000B3\nsup=02283\nsupE=02AC6\nsupdot=02ABE\nsupdsub=02AD8\nsupe=02287\nsupedot=02AC4\nsuphsol=027C9\nsuphsub=02AD7\nsuplarr=0297B\nsupmult=02AC2\nsupnE=02ACC\nsupne=0228B\nsupplus=02AC0\nsupset=02283\nsupseteq=02287\nsupseteqq=02AC6\nsupsetneq=0228B\nsupsetneqq=02ACC\nsupsim=02AC8\nsupsub=02AD4\nsupsup=02AD6\nswArr=021D9\nswarhk=02926\nswarr=02199\nswarrow=02199\nswnwar=0292A\nszlig=000DF\ntarget=02316\ntau=003C4\ntbrk=023B4\ntcaron=00165\ntcedil=00163\ntcy=00442\ntdot=020DB\ntelrec=02315\ntfr=1D531\nthere4=02234\ntherefore=02234\ntheta=003B8\nthetasym=003D1\nthetav=003D1\nthickapprox=02248\nthicksim=0223C\nthinsp=02009\nthkap=02248\nthksim=0223C\nthorn=000FE\ntilde=002DC\ntimes=000D7\ntimesb=022A0\ntimesbar=02A31\ntimesd=02A30\ntint=0222D\ntoea=02928\ntop=022A4\ntopbot=02336\ntopcir=02AF1\ntopf=1D565\ntopfork=02ADA\ntosa=02929\ntprime=02034\ntrade=02122\ntriangle=025B5\ntriangledown=025BF\ntriangleleft=025C3\ntrianglelefteq=022B4\ntriangleq=0225C\ntriangleright=025B9\ntrianglerighteq=022B5\ntridot=025EC\ntrie=0225C\ntriminus=02A3A\ntriplus=02A39\ntrisb=029CD\ntritime=02A3B\ntrpezium=023E2\ntscr=1D4C9\ntscy=00446\ntshcy=0045B\ntstrok=00167\ntwixt=0226C\ntwoheadleftarrow=0219E\ntwoheadrightarrow=021A0\nuArr=021D1\nuHar=02963\nuacute=000FA\nuarr=02191\nubrcy=0045E\nubreve=0016D\nucirc=000FB\nucy=00443\nudarr=021C5\nudblac=00171\nudhar=0296E\nufisht=0297E\nufr=1D532\nugrave=000F9\nuharl=021BF\nuharr=021BE\nuhblk=02580\nulcorn=0231C\nulcorner=0231C\nulcrop=0230F\nultri=025F8\numacr=0016B\numl=000A8\nuogon=00173\nuopf=1D566\nuparrow=02191\nupdownarrow=02195\nupharpoonleft=021BF\nupharpoonright=021BE\nuplus=0228E\nupsi=003C5\nupsih=003D2\nupsilon=003C5\nupuparrows=021C8\nurcorn=0231D\nurcorner=0231D\nurcrop=0230E\nuring=0016F\nurtri=025F9\nuscr=1D4CA\nutdot=022F0\nutilde=00169\nutri=025B5\nutrif=025B4\nuuarr=021C8\nuuml=000FC\nuwangle=029A7\nvArr=021D5\nvBar=02AE8\nvBarv=02AE9\nvDash=022A8\nvangrt=0299C\nvarepsilon=003F5\nvarkappa=003F0\nvarnothing=02205\nvarphi=003D5\nvarpi=003D6\nvarpropto=0221D\nvarr=02195\nvarrho=003F1\nvarsigma=003C2\nvartheta=003D1\nvartriangleleft=022B2\nvartriangleright=022B3\nvcy=00432\nvdash=022A2\nvee=02228\nveebar=022BB\nveeeq=0225A\nvellip=022EE\nverbar=0007C\nvert=0007C\nvfr=1D533\nvltri=022B2\nvopf=1D567\nvprop=0221D\nvrtri=022B3\nvscr=1D4CB\nvzigzag=0299A\nwcirc=00175\nwedbar=02A5F\nwedge=02227\nwedgeq=02259\nweierp=02118\nwfr=1D534\nwopf=1D568\nwp=02118\nwr=02240\nwreath=02240\nwscr=1D4CC\nxcap=022C2\nxcirc=025EF\nxcup=022C3\nxdtri=025BD\nxfr=1D535\nxhArr=027FA\nxharr=027F7\nxi=003BE\nxlArr=027F8\nxlarr=027F5\nxmap=027FC\nxnis=022FB\nxodot=02A00\nxopf=1D569\nxoplus=02A01\nxotime=02A02\nxrArr=027F9\nxrarr=027F6\nxscr=1D4CD\nxsqcup=02A06\nxuplus=02A04\nxutri=025B3\nxvee=022C1\nxwedge=022C0\nyacute=000FD\nyacy=0044F\nycirc=00177\nycy=0044B\nyen=000A5\nyfr=1D536\nyicy=00457\nyopf=1D56A\nyscr=1D4CE\nyucy=0044E\nyuml=000FF\nzacute=0017A\nzcaron=0017E\nzcy=00437\nzdot=0017C\nzeetrf=02128\nzeta=003B6\nzfr=1D537\nzhcy=00436\nzigrarr=021DD\nzopf=1D56B\nzscr=1D4CF\nzwj=0200D\nzwnj=0200C\n"

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->c(Ljava/lang/String;)Ljava/util/Map;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a:Ljava/util/Map;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a:Ljava/util/Map;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a(Ljava/util/Map;)Ljava/util/Map;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->d:Ljava/util/Map;

    sget-object v3, Lcom/igexin/push/extension/distribution/basic/i/b/j;->g:[[Ljava/lang/Object;

    array-length v4, v3

    move v1, v2

    :goto_0
    if-ge v1, v4, :cond_0

    aget-object v5, v3, v1

    aget-object v0, v5, v8

    check-cast v0, Ljava/lang/Integer;

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    int-to-char v0, v0

    invoke-static {v0}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v6

    sget-object v7, Lcom/igexin/push/extension/distribution/basic/i/b/j;->b:Ljava/util/Map;

    aget-object v0, v5, v2

    check-cast v0, Ljava/lang/String;

    invoke-interface {v7, v6, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_0

    :cond_0
    return-void
.end method

.method static a(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/f;)Ljava/lang/String;
    .locals 2

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->c()Ljava/nio/charset/CharsetEncoder;

    move-result-object v0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->a()Lcom/igexin/push/extension/distribution/basic/i/b/k;

    move-result-object v1

    invoke-static {p0, v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a(Ljava/lang/String;Ljava/nio/charset/CharsetEncoder;Lcom/igexin/push/extension/distribution/basic/i/b/k;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static a(Ljava/lang/String;Ljava/nio/charset/CharsetEncoder;Lcom/igexin/push/extension/distribution/basic/i/b/k;)Ljava/lang/String;
    .locals 6

    const/16 v5, 0x3b

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v0

    mul-int/lit8 v0, v0, 0x2

    invoke-direct {v2, v0}, Ljava/lang/StringBuilder;-><init>(I)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/b/k;->a()Ljava/util/Map;

    move-result-object v3

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v0

    if-ge v1, v0, :cond_2

    invoke-virtual {p0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v0

    invoke-static {v0}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v0

    invoke-interface {v3, v0}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_0

    const/16 v4, 0x26

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-interface {v3, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    :goto_1
    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_0

    :cond_0
    invoke-virtual {v0}, Ljava/lang/Character;->charValue()C

    move-result v4

    invoke-virtual {p1, v4}, Ljava/nio/charset/CharsetEncoder;->canEncode(C)Z

    move-result v4

    if-eqz v4, :cond_1

    invoke-virtual {v0}, Ljava/lang/Character;->charValue()C

    move-result v0

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    goto :goto_1

    :cond_1
    const-string v4, "&#"

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v0}, Ljava/lang/Character;->charValue()C

    move-result v0

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    goto :goto_1

    :cond_2
    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static synthetic a()Ljava/util/Map;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->b:Ljava/util/Map;

    return-object v0
.end method

.method private static a(Ljava/util/Map;)Ljava/util/Map;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Character;",
            ">;)",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/Character;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    invoke-interface {p0}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :cond_0
    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/Character;

    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-interface {v2, v1}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1

    invoke-virtual {v0}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v4, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_0

    invoke-interface {v2, v1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    :cond_1
    invoke-interface {v2, v1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    :cond_2
    return-object v2
.end method

.method public static a(Ljava/lang/String;)Z
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a:Ljava/util/Map;

    invoke-interface {v0, p0}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    return v0
.end method

.method public static b(Ljava/lang/String;)Ljava/lang/Character;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a:Ljava/util/Map;

    invoke-interface {v0, p0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Character;

    return-object v0
.end method

.method static synthetic b()Ljava/util/Map;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->c:Ljava/util/Map;

    return-object v0
.end method

.method static synthetic c()Ljava/util/Map;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/j;->d:Ljava/util/Map;

    return-object v0
.end method

.method private static c(Ljava/lang/String;)Ljava/util/Map;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Character;",
            ">;"
        }
    .end annotation

    new-instance v0, Ljava/util/Properties;

    invoke-direct {v0}, Ljava/util/Properties;-><init>()V

    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    :try_start_0
    new-instance v1, Ljava/io/ByteArrayInputStream;

    const-string v3, "UTF-8"

    invoke-virtual {p0, v3}, Ljava/lang/String;->getBytes(Ljava/lang/String;)[B

    move-result-object v3

    invoke-direct {v1, v3}, Ljava/io/ByteArrayInputStream;-><init>([B)V

    invoke-virtual {v0, v1}, Ljava/util/Properties;->load(Ljava/io/InputStream;)V

    invoke-virtual {v1}, Ljava/io/InputStream;->close()V
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_0

    invoke-virtual {v0}, Ljava/util/Properties;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    const/16 v4, 0x10

    invoke-static {v1, v4}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;I)I

    move-result v1

    int-to-char v1, v1

    invoke-static {v1}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v1

    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-interface {v2, v0, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    :catch_0
    move-exception v0

    new-instance v1, Ljava/util/MissingResourceException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Error loading entities resource: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Ljava/io/IOException;->getMessage()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v2, "Entities"

    invoke-direct {v1, v0, v2, p0}, Ljava/util/MissingResourceException;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    throw v1

    :cond_0
    return-object v2
.end method
