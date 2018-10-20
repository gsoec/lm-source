.class public Lcom/igg/iggsdkbusiness/AppsFlyerHelper;
.super Ljava/lang/Object;
.source "AppsFlyerHelper.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/AppsFlyerHelper;


# instance fields
.field OnAppOpenAttribution:Ljava/lang/String;

.field OnAttributionFailure:Ljava/lang/String;

.field OnInstallConversionDataLoaded:Ljava/lang/String;

.field OnInstallConversionFailure:Ljava/lang/String;

.field private formatter:Ljava/text/SimpleDateFormat;

.field private storage:Lcom/igg/util/LocalStorage;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 216
    const/4 v0, 0x0

    sput-object v0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->instance:Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    return-void
.end method

.method public constructor <init>()V
    .locals 3

    .prologue
    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 30
    const-string v0, "OnInstallConversionDataLoaded"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->OnInstallConversionDataLoaded:Ljava/lang/String;

    .line 31
    const-string v0, "OnInstallConversionFailure"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->OnInstallConversionFailure:Ljava/lang/String;

    .line 32
    const-string v0, "OnAppOpenAttribution"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->OnAppOpenAttribution:Ljava/lang/String;

    .line 33
    const-string v0, "OnAttributionFailure"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->OnAttributionFailure:Ljava/lang/String;

    .line 38
    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy\u5e74MM\u6708dd\u65e5"

    invoke-direct {v0, v1}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    .line 40
    new-instance v0, Lcom/igg/util/LocalStorage;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-virtual {v1}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    const-string v2, "appsflyer_event_file"

    invoke-direct {v0, v1, v2}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    .line 53
    return-void
.end method

.method private GetEventValue()Ljava/util/Map;
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;"
        }
    .end annotation

    .prologue
    .line 230
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 231
    .local v0, "eventValue":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    const-string v1, "userid"

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 232
    return-object v0
.end method

.method private getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 226
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/AppsFlyerHelper;
    .locals 1

    .prologue
    .line 219
    sget-object v0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->instance:Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    if-nez v0, :cond_0

    .line 220
    new-instance v0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->instance:Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    .line 222
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->instance:Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    return-object v0
.end method


# virtual methods
.method public AddDeepLinkHandler()V
    .locals 4

    .prologue
    .line 239
    const-string v1, "AppsFlyer_4.8.14"

    const-string v2, "GetDPValue "

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 242
    :try_start_0
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v1

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v2

    invoke-virtual {v2}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v2

    new-instance v3, Lcom/igg/iggsdkbusiness/AppsFlyerHelper$1;

    invoke-direct {v3, p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper$1;-><init>(Lcom/igg/iggsdkbusiness/AppsFlyerHelper;)V

    invoke-virtual {v1, v2, v3}, Lcom/appsflyer/AppsFlyerLib;->registerConversionListener(Landroid/content/Context;Lcom/appsflyer/AppsFlyerConversionListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 281
    :goto_0
    return-void

    .line 277
    :catch_0
    move-exception v0

    .line 279
    .local v0, "e":Ljava/lang/Exception;
    const-string v1, "AppsFlyer_4.8.14"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Exception = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public AdvanceEvent(Ljava/lang/String;)V
    .locals 3
    .param p1, "name"    # Ljava/lang/String;

    .prologue
    .line 182
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-virtual {v1}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->GetEventValue()Ljava/util/Map;

    move-result-object v2

    invoke-virtual {v0, v1, p1, v2}, Lcom/appsflyer/AppsFlyerLib;->trackEvent(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 183
    return-void
.end method

.method public AppsFlyerSignUp()V
    .locals 11

    .prologue
    const/4 v10, 0x1

    const/4 v7, 0x0

    .line 87
    new-instance v0, Ljava/util/Date;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v8

    invoke-direct {v0, v8, v9}, Ljava/util/Date;-><init>(J)V

    .line 88
    .local v0, "curDate":Ljava/util/Date;
    invoke-virtual {v0, v7}, Ljava/util/Date;->setHours(I)V

    .line 89
    invoke-virtual {v0, v7}, Ljava/util/Date;->setMinutes(I)V

    .line 90
    invoke-virtual {v0, v7}, Ljava/util/Date;->setSeconds(I)V

    .line 91
    const-string v7, "AppsFlyer"

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "curDate = "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    iget-object v9, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v9, v0}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 92
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v8, "signUpFlag"

    invoke-virtual {v7, v8}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v5

    .line 93
    .local v5, "signUpFlag":Z
    if-nez v5, :cond_0

    .line 95
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v8, "signUpFlag"

    invoke-virtual {v7, v8, v10}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 98
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v7

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v8

    invoke-virtual {v8}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v8

    const-string v9, "SIGN_UP"

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->GetEventValue()Ljava/util/Map;

    move-result-object v10

    invoke-virtual {v7, v8, v9, v10}, Lcom/appsflyer/AppsFlyerLib;->trackEvent(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 99
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v7, v0}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v6

    .line 100
    .local v6, "str":Ljava/lang/String;
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v8, "APPSFLYER_FIRST_TIME"

    invoke-virtual {v7, v8, v6}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V

    .line 101
    const-string v7, "signUpFlag"

    const-string v8, "signUpFlag"

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 104
    .end local v6    # "str":Ljava/lang/String;
    :cond_0
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v8, "APPSFLYER_DAY2_RETENTION"

    invoke-virtual {v7, v8}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v3

    .line 105
    .local v3, "day2retention":Z
    if-eqz v5, :cond_1

    if-nez v3, :cond_1

    .line 107
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v8, "APPSFLYER_FIRST_TIME"

    invoke-virtual {v7, v8}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 110
    .local v2, "dateStr":Ljava/lang/String;
    :try_start_0
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v7, v2}, Ljava/text/SimpleDateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object v1

    .line 113
    .local v1, "date":Ljava/util/Date;
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->CheckDay2()Z

    move-result v7

    if-eqz v7, :cond_2

    .line 118
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v7

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v8

    invoke-virtual {v8}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v8

    const-string v9, "DAY2_RETENTION"

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->GetEventValue()Ljava/util/Map;

    move-result-object v10

    invoke-virtual {v7, v8, v9, v10}, Lcom/appsflyer/AppsFlyerLib;->trackEvent(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 119
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v8, "APPSFLYER_DAY2_RETENTION"

    const/4 v9, 0x1

    invoke-virtual {v7, v8, v9}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 120
    const-string v7, "AppsFlyer"

    const-string v8, "SIGN_UP Event = true"

    invoke-static {v7, v8}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 133
    .end local v1    # "date":Ljava/util/Date;
    .end local v2    # "dateStr":Ljava/lang/String;
    :cond_1
    :goto_0
    return-void

    .line 124
    .restart local v1    # "date":Ljava/util/Date;
    .restart local v2    # "dateStr":Ljava/lang/String;
    :cond_2
    const-string v7, "AppsFlyer"

    const-string v8, "SIGN_UP Event = false"

    invoke-static {v7, v8}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/text/ParseException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 128
    .end local v1    # "date":Ljava/util/Date;
    :catch_0
    move-exception v4

    .line 130
    .local v4, "e":Ljava/text/ParseException;
    invoke-virtual {v4}, Ljava/text/ParseException;->printStackTrace()V

    goto :goto_0
.end method

.method public CheckDay2()Z
    .locals 13

    .prologue
    const/16 v12, 0xe

    const/4 v7, 0x1

    const/4 v8, 0x0

    .line 186
    const/4 v0, 0x0

    .line 188
    .local v0, "bRes":Z
    iget-object v9, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v10, "APPSFLYER_FIRST_TIME"

    invoke-virtual {v9, v10}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 189
    .local v5, "dateStr":Ljava/lang/String;
    const/4 v4, 0x0

    .line 191
    .local v4, "date":Ljava/util/Date;
    :try_start_0
    iget-object v9, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v9, v5}, Ljava/text/SimpleDateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;
    :try_end_0
    .catch Ljava/text/ParseException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v4

    .line 197
    :goto_0
    new-instance v3, Ljava/util/Date;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v10

    invoke-direct {v3, v10, v11}, Ljava/util/Date;-><init>(J)V

    .line 198
    .local v3, "curDate":Ljava/util/Date;
    invoke-virtual {v3, v8}, Ljava/util/Date;->setHours(I)V

    invoke-virtual {v3, v8}, Ljava/util/Date;->setMinutes(I)V

    invoke-virtual {v3, v8}, Ljava/util/Date;->setSeconds(I)V

    .line 200
    invoke-static {}, Ljava/util/Calendar;->getInstance()Ljava/util/Calendar;

    move-result-object v1

    .line 201
    .local v1, "cal":Ljava/util/Calendar;
    invoke-static {}, Ljava/util/Calendar;->getInstance()Ljava/util/Calendar;

    move-result-object v2

    .line 202
    .local v2, "curCal":Ljava/util/Calendar;
    invoke-virtual {v2, v3}, Ljava/util/Calendar;->setTime(Ljava/util/Date;)V

    .line 203
    invoke-virtual {v2, v12, v8}, Ljava/util/Calendar;->set(II)V

    .line 205
    invoke-virtual {v1, v4}, Ljava/util/Calendar;->setTime(Ljava/util/Date;)V

    .line 206
    const/4 v9, 0x5

    invoke-virtual {v1, v9, v7}, Ljava/util/Calendar;->add(II)V

    .line 207
    invoke-virtual {v1, v12, v8}, Ljava/util/Calendar;->set(II)V

    .line 209
    invoke-virtual {v1, v2}, Ljava/util/Calendar;->compareTo(Ljava/util/Calendar;)I

    move-result v9

    if-nez v9, :cond_0

    move v0, v7

    .line 210
    :goto_1
    const-string v7, "Calendar"

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "APPSFLYER_FIRST_TIME = "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 211
    const-string v7, "Calendar"

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Date +1= "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    iget-object v9, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v1}, Ljava/util/Calendar;->getTime()Ljava/util/Date;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 212
    const-string v7, "Calendar"

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "bRes = "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 213
    const-string v7, "Calendar"

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "compareTo = "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v1, v2}, Ljava/util/Calendar;->compareTo(Ljava/util/Calendar;)I

    move-result v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 214
    return v0

    .line 192
    .end local v1    # "cal":Ljava/util/Calendar;
    .end local v2    # "curCal":Ljava/util/Calendar;
    .end local v3    # "curDate":Ljava/util/Date;
    :catch_0
    move-exception v6

    .line 194
    .local v6, "e":Ljava/text/ParseException;
    invoke-virtual {v6}, Ljava/text/ParseException;->printStackTrace()V

    goto/16 :goto_0

    .end local v6    # "e":Ljava/text/ParseException;
    .restart local v1    # "cal":Ljava/util/Calendar;
    .restart local v2    # "curCal":Ljava/util/Calendar;
    .restart local v3    # "curDate":Ljava/util/Date;
    :cond_0
    move v0, v8

    .line 209
    goto :goto_1
.end method

.method public HeroStageCompletion()V
    .locals 4

    .prologue
    .line 176
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-virtual {v1}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    const-string v2, "HEROSTAGE1-3_COMPLETION"

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->GetEventValue()Ljava/util/Map;

    move-result-object v3

    invoke-virtual {v0, v1, v2, v3}, Lcom/appsflyer/AppsFlyerLib;->trackEvent(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 178
    return-void
.end method

.method public LaunchEvent()V
    .locals 9

    .prologue
    const/4 v5, 0x0

    .line 136
    const-string v1, ""

    .line 137
    .local v1, "curDateStr":Ljava/lang/String;
    new-instance v0, Ljava/util/Date;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    invoke-direct {v0, v6, v7}, Ljava/util/Date;-><init>(J)V

    .line 138
    .local v0, "curDate":Ljava/util/Date;
    invoke-virtual {v0, v5}, Ljava/util/Date;->setHours(I)V

    invoke-virtual {v0, v5}, Ljava/util/Date;->setMinutes(I)V

    invoke-virtual {v0, v5}, Ljava/util/Date;->setSeconds(I)V

    .line 139
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v6, "APPSFLYER_LAUNCH_TIME"

    invoke-virtual {v5, v6}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 140
    .local v3, "launchTime":Ljava/lang/String;
    if-eqz v3, :cond_0

    const-string v5, ""

    if-ne v3, v5, :cond_1

    .line 142
    :cond_0
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v5, v0}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v1

    .line 143
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v6, "APPSFLYER_LAUNCH_TIME"

    invoke-virtual {v5, v6, v1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V

    .line 147
    :cond_1
    :try_start_0
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v5, v3}, Ljava/text/SimpleDateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object v2

    .line 148
    .local v2, "date":Ljava/util/Date;
    const/4 v5, 0x0

    invoke-virtual {v2, v5}, Ljava/util/Date;->setHours(I)V

    const/4 v5, 0x0

    invoke-virtual {v2, v5}, Ljava/util/Date;->setMinutes(I)V

    const/4 v5, 0x0

    invoke-virtual {v2, v5}, Ljava/util/Date;->setSeconds(I)V

    .line 149
    invoke-virtual {v0}, Ljava/util/Date;->getYear()I

    move-result v5

    invoke-virtual {v2}, Ljava/util/Date;->getYear()I

    move-result v6

    if-lt v5, v6, :cond_2

    .line 150
    invoke-virtual {v0}, Ljava/util/Date;->getMonth()I

    move-result v5

    invoke-virtual {v2}, Ljava/util/Date;->getMonth()I

    move-result v6

    if-lt v5, v6, :cond_2

    .line 151
    invoke-virtual {v0}, Ljava/util/Date;->getDate()I

    move-result v5

    invoke-virtual {v2}, Ljava/util/Date;->getDate()I

    move-result v6

    if-le v5, v6, :cond_2

    .line 155
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v5

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-virtual {v6}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v6

    const-string v7, "IGG_LAUNCH"

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->GetEventValue()Ljava/util/Map;

    move-result-object v8

    invoke-virtual {v5, v6, v7, v8}, Lcom/appsflyer/AppsFlyerLib;->trackEvent(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 156
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v5, v0}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v4

    .line 157
    .local v4, "str":Ljava/lang/String;
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v6, "APPSFLYER_LAUNCH_TIME"

    invoke-virtual {v5, v6, v4}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V

    .line 158
    const-string v5, "AppsFlyer"

    const-string v6, "LaunchEvent  = true"

    invoke-static {v5, v6}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 165
    .end local v2    # "date":Ljava/util/Date;
    .end local v4    # "str":Ljava/lang/String;
    :goto_0
    return-void

    .line 161
    .restart local v2    # "date":Ljava/util/Date;
    :cond_2
    const-string v5, "AppsFlyer"

    const-string v6, "LaunchEvent  = false"

    invoke-static {v5, v6}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/text/ParseException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 164
    .end local v2    # "date":Ljava/util/Date;
    :catch_0
    move-exception v5

    goto :goto_0
.end method

.method public SetAppsFlyerKey()V
    .locals 6

    .prologue
    const/4 v5, 0x1

    .line 56
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 57
    .local v1, "jsonObject":Lorg/json/JSONObject;
    const-string v0, ""

    .line 58
    .local v0, "customerUserData":Ljava/lang/String;
    const-string v2, "AppsFlyer"

    const-string v3, "try  jsonObject.put "

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 62
    :try_start_0
    const-string v2, "g_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 63
    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .line 65
    :goto_0
    const-string v2, "AppsFlyer"

    const-string v3, "AppsFlyerCollect"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 66
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-virtual {v2, v5}, Lcom/appsflyer/AppsFlyerLib;->setCollectIMEI(Z)V

    .line 67
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-virtual {v2, v5}, Lcom/appsflyer/AppsFlyerLib;->setCollectAndroidID(Z)V

    .line 68
    const-string v2, "AppsFlyer"

    const-string v3, "AppsFlyerLib.getInstance().setCustomerUserId()-Start"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 69
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-virtual {v2, v0}, Lcom/appsflyer/AppsFlyerLib;->setCustomerUserId(Ljava/lang/String;)V

    .line 70
    const-string v2, "AppsFlyer"

    const-string v3, "AppsFlyerLib.getInstance().setCustomerUserId()-End"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 71
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->AddDeepLinkHandler()V

    .line 72
    const-string v2, "AppsFlyer"

    const-string v3, "AppsFlyerLib.getInstance().trackAppLaunch()-Start"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 73
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v3

    const-string v4, "WEYqZmRBi6ZmFww2esj28Y"

    invoke-virtual {v2, v3, v4}, Lcom/appsflyer/AppsFlyerLib;->trackAppLaunch(Landroid/content/Context;Ljava/lang/String;)V

    .line 74
    const-string v2, "AppsFlyer"

    const-string v3, "AppsFlyerLib.getInstance().trackAppLaunch()-End"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 76
    const-string v2, "AppsFlyer"

    const-string v3, "AppsFlyerLib.getInstance().startTracking()-Start"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 77
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v3

    const-string v4, "WEYqZmRBi6ZmFww2esj28Y"

    invoke-virtual {v2, v3, v4}, Lcom/appsflyer/AppsFlyerLib;->startTracking(Landroid/app/Application;Ljava/lang/String;)V

    .line 78
    const-string v2, "AppsFlyer"

    const-string v3, "AppsFlyerLib.getInstance().startTracking()-End"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 79
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-virtual {v2, v5}, Lcom/appsflyer/AppsFlyerLib;->setDebugLog(Z)V

    .line 80
    return-void

    .line 64
    :catch_0
    move-exception v2

    goto :goto_0
.end method

.method public TutorialCompletion()V
    .locals 4

    .prologue
    .line 170
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-virtual {v1}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    const-string v2, "TUTORIAL_COMPLETION"

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->GetEventValue()Ljava/util/Map;

    move-result-object v3

    invoke-virtual {v0, v1, v2, v3}, Lcom/appsflyer/AppsFlyerLib;->trackEvent(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 171
    return-void
.end method
