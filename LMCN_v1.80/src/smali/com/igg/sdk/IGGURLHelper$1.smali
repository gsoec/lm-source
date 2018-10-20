.class synthetic Lcom/igg/sdk/IGGURLHelper$1;
.super Ljava/lang/Object;
.source "IGGURLHelper.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/IGGURLHelper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1008
    name = null
.end annotation


# static fields
.field static final synthetic $SwitchMap$com$igg$sdk$IGGSDKConstant$CDNType:[I

.field static final synthetic $SwitchMap$com$igg$sdk$IGGSDKConstant$IGGAppConfigContentFormat:[I

.field static final synthetic $SwitchMap$com$igg$sdk$IGGSDKConstant$IGGIDC:[I

.field static final synthetic $SwitchMap$com$igg$sdk$IGGSDKConstant$PayDNS:[I


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .prologue
    .line 331
    invoke-static {}, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->values()[Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    move-result-object v0

    array-length v0, v0

    new-array v0, v0, [I

    sput-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$PayDNS:[I

    :try_start_0
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$PayDNS:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_SKYUNION:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->ordinal()I

    move-result v1

    const/4 v2, 0x1

    aput v2, v0, v1
    :try_end_0
    .catch Ljava/lang/NoSuchFieldError; {:try_start_0 .. :try_end_0} :catch_9

    :goto_0
    :try_start_1
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$PayDNS:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->ordinal()I

    move-result v1

    const/4 v2, 0x2

    aput v2, v0, v1
    :try_end_1
    .catch Ljava/lang/NoSuchFieldError; {:try_start_1 .. :try_end_1} :catch_8

    .line 190
    :goto_1
    invoke-static {}, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->values()[Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    move-result-object v0

    array-length v0, v0

    new-array v0, v0, [I

    sput-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGAppConfigContentFormat:[I

    :try_start_2
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGAppConfigContentFormat:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->JSON:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->ordinal()I

    move-result v1

    const/4 v2, 0x1

    aput v2, v0, v1
    :try_end_2
    .catch Ljava/lang/NoSuchFieldError; {:try_start_2 .. :try_end_2} :catch_7

    :goto_2
    :try_start_3
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGAppConfigContentFormat:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->XML:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;->ordinal()I

    move-result v1

    const/4 v2, 0x2

    aput v2, v0, v1
    :try_end_3
    .catch Ljava/lang/NoSuchFieldError; {:try_start_3 .. :try_end_3} :catch_6

    .line 141
    :goto_3
    invoke-static {}, Lcom/igg/sdk/IGGSDKConstant$CDNType;->values()[Lcom/igg/sdk/IGGSDKConstant$CDNType;

    move-result-object v0

    array-length v0, v0

    new-array v0, v0, [I

    sput-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$CDNType:[I

    :try_start_4
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$CDNType:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$CDNType;->STATIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$CDNType;->ordinal()I

    move-result v1

    const/4 v2, 0x1

    aput v2, v0, v1
    :try_end_4
    .catch Ljava/lang/NoSuchFieldError; {:try_start_4 .. :try_end_4} :catch_5

    :goto_4
    :try_start_5
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$CDNType:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$CDNType;->DYNAMIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$CDNType;->ordinal()I

    move-result v1

    const/4 v2, 0x2

    aput v2, v0, v1
    :try_end_5
    .catch Ljava/lang/NoSuchFieldError; {:try_start_5 .. :try_end_5} :catch_4

    .line 104
    :goto_5
    invoke-static {}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->values()[Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    move-result-object v0

    array-length v0, v0

    new-array v0, v0, [I

    sput-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGIDC:[I

    :try_start_6
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGIDC:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->ordinal()I

    move-result v1

    const/4 v2, 0x1

    aput v2, v0, v1
    :try_end_6
    .catch Ljava/lang/NoSuchFieldError; {:try_start_6 .. :try_end_6} :catch_3

    :goto_6
    :try_start_7
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGIDC:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SG:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->ordinal()I

    move-result v1

    const/4 v2, 0x2

    aput v2, v0, v1
    :try_end_7
    .catch Ljava/lang/NoSuchFieldError; {:try_start_7 .. :try_end_7} :catch_2

    :goto_7
    :try_start_8
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGIDC:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->ordinal()I

    move-result v1

    const/4 v2, 0x3

    aput v2, v0, v1
    :try_end_8
    .catch Ljava/lang/NoSuchFieldError; {:try_start_8 .. :try_end_8} :catch_1

    :goto_8
    :try_start_9
    sget-object v0, Lcom/igg/sdk/IGGURLHelper$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGIDC:[I

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->ordinal()I

    move-result v1

    const/4 v2, 0x4

    aput v2, v0, v1
    :try_end_9
    .catch Ljava/lang/NoSuchFieldError; {:try_start_9 .. :try_end_9} :catch_0

    :goto_9
    return-void

    :catch_0
    move-exception v0

    goto :goto_9

    :catch_1
    move-exception v0

    goto :goto_8

    :catch_2
    move-exception v0

    goto :goto_7

    :catch_3
    move-exception v0

    goto :goto_6

    .line 141
    :catch_4
    move-exception v0

    goto :goto_5

    :catch_5
    move-exception v0

    goto :goto_4

    .line 190
    :catch_6
    move-exception v0

    goto :goto_3

    :catch_7
    move-exception v0

    goto :goto_2

    .line 331
    :catch_8
    move-exception v0

    goto/16 :goto_1

    :catch_9
    move-exception v0

    goto/16 :goto_0
.end method
