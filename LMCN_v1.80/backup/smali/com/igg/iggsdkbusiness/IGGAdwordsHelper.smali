.class public Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;
.super Ljava/lang/Object;
.source "IGGAdwordsHelper.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;


# instance fields
.field final CONVERSION_ID:Ljava/lang/String;

.field final DAY2_FLAG:Ljava/lang/String;

.field final DAY2_RETENTION:Ljava/lang/String;

.field final FILE_NAME:Ljava/lang/String;

.field final HEROSTAGE1_3:Ljava/lang/String;

.field final HEROSTAGE1_3_FLAG:Ljava/lang/String;

.field final INSTALL:Ljava/lang/String;

.field final INSTALL_FLAG:Ljava/lang/String;

.field final JOIN_GUILD:Ljava/lang/String;

.field final JOIN_GUILD_FLAG:Ljava/lang/String;

.field final PAY:Ljava/lang/String;

.field final REACH_CASTLE5:Ljava/lang/String;

.field final REACH_CASTLE5_FLAG:Ljava/lang/String;

.field final SIGNUP_FLAG:Ljava/lang/String;

.field final SIGNUP_TIME:Ljava/lang/String;

.field final TAG:Ljava/lang/String;

.field private formatter:Ljava/text/SimpleDateFormat;

.field storage:Lcom/igg/util/LocalStorage;


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 61
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 32
    const-string v0, "IGGAdwordsHelper"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->TAG:Ljava/lang/String;

    .line 33
    const-string v0, "ADWORDS_EVENT_FILE"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->FILE_NAME:Ljava/lang/String;

    .line 34
    const-string v0, "INSTALL_FLAG"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->INSTALL_FLAG:Ljava/lang/String;

    .line 35
    const-string v0, "SIGNUP_FLAG"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->SIGNUP_FLAG:Ljava/lang/String;

    .line 36
    const-string v0, "SIGNUP_TIME"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->SIGNUP_TIME:Ljava/lang/String;

    .line 37
    const-string v0, "DAY2_FLAG"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->DAY2_FLAG:Ljava/lang/String;

    .line 38
    const-string v0, "JOIN_GUILD_FLAG"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->JOIN_GUILD_FLAG:Ljava/lang/String;

    .line 39
    const-string v0, "REACH_CASTLE5_FLAG"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->REACH_CASTLE5_FLAG:Ljava/lang/String;

    .line 40
    const-string v0, "HEROSTAGE1_3_FLAG"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->HEROSTAGE1_3_FLAG:Ljava/lang/String;

    .line 42
    const-string v0, "844484708"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->CONVERSION_ID:Ljava/lang/String;

    .line 43
    const-string v0, "C2bJCK-Mr3UQ5KDXkgM"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->INSTALL:Ljava/lang/String;

    .line 44
    const-string v0, "7afWCKe4x3UQ5KDXkgM"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->JOIN_GUILD:Ljava/lang/String;

    .line 45
    const-string v0, "MbrwCPi3r3UQ5KDXkgM"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->REACH_CASTLE5:Ljava/lang/String;

    .line 46
    const-string v0, "-EkgCKWtx3UQ5KDXkgM"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->DAY2_RETENTION:Ljava/lang/String;

    .line 47
    const-string v0, "mURfCIa0r3UQ5KDXkgM"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->HEROSTAGE1_3:Ljava/lang/String;

    .line 48
    const-string v0, "06hPCNazr3UQ5KDXkgM"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->PAY:Ljava/lang/String;

    .line 62
    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy\u5e74MM\u6708dd\u65e5"

    invoke-direct {v0, v1}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->formatter:Ljava/text/SimpleDateFormat;

    .line 63
    new-instance v0, Lcom/igg/util/LocalStorage;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-virtual {v1}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    const-string v2, "ADWORDS_EVENT_FILE"

    invoke-direct {v0, v1, v2}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    .line 64
    return-void
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;)Landroid/app/Activity;
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    .prologue
    .line 30
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method private getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 235
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;
    .locals 1

    .prologue
    .line 55
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->instance:Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    if-nez v0, :cond_0

    .line 56
    new-instance v0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->instance:Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    .line 58
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->instance:Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    return-object v0
.end method


# virtual methods
.method CheckDay2()Z
    .locals 12

    .prologue
    const/4 v7, 0x1

    const/4 v8, 0x0

    .line 190
    const/4 v0, 0x0

    .line 193
    .local v0, "bRes":Z
    iget-object v9, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v10, "SIGNUP_TIME"

    invoke-virtual {v9, v10}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 194
    .local v5, "dateStr":Ljava/lang/String;
    const/4 v4, 0x0

    .line 196
    .local v4, "date":Ljava/util/Date;
    if-eqz v5, :cond_0

    :try_start_0
    const-string v9, ""

    invoke-virtual {v5, v9}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v9

    if-nez v9, :cond_0

    .line 198
    const-string v9, "IGGAdwordsHelper"

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "dateStr = "

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-static {v9, v10}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 199
    iget-object v9, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->formatter:Ljava/text/SimpleDateFormat;

    invoke-virtual {v9, v5}, Ljava/text/SimpleDateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object v4

    .line 200
    new-instance v3, Ljava/util/Date;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v10

    invoke-direct {v3, v10, v11}, Ljava/util/Date;-><init>(J)V

    .line 201
    .local v3, "curDate":Ljava/util/Date;
    const/4 v9, 0x0

    invoke-virtual {v3, v9}, Ljava/util/Date;->setHours(I)V

    const/4 v9, 0x0

    invoke-virtual {v3, v9}, Ljava/util/Date;->setMinutes(I)V

    const/4 v9, 0x0

    invoke-virtual {v3, v9}, Ljava/util/Date;->setSeconds(I)V

    .line 203
    invoke-static {}, Ljava/util/Calendar;->getInstance()Ljava/util/Calendar;

    move-result-object v1

    .line 204
    .local v1, "cal":Ljava/util/Calendar;
    invoke-static {}, Ljava/util/Calendar;->getInstance()Ljava/util/Calendar;

    move-result-object v2

    .line 205
    .local v2, "curCal":Ljava/util/Calendar;
    invoke-virtual {v2, v3}, Ljava/util/Calendar;->setTime(Ljava/util/Date;)V

    .line 206
    const/16 v9, 0xe

    const/4 v10, 0x0

    invoke-virtual {v2, v9, v10}, Ljava/util/Calendar;->set(II)V

    .line 208
    invoke-virtual {v1, v4}, Ljava/util/Calendar;->setTime(Ljava/util/Date;)V

    .line 209
    const/4 v9, 0x5

    const/4 v10, 0x1

    invoke-virtual {v1, v9, v10}, Ljava/util/Calendar;->add(II)V

    .line 210
    const/16 v9, 0xe

    const/4 v10, 0x0

    invoke-virtual {v1, v9, v10}, Ljava/util/Calendar;->set(II)V

    .line 212
    invoke-virtual {v1, v2}, Ljava/util/Calendar;->compareTo(Ljava/util/Calendar;)I
    :try_end_0
    .catch Ljava/text/ParseException; {:try_start_0 .. :try_end_0} :catch_0

    move-result v9

    if-nez v9, :cond_1

    move v0, v7

    .end local v1    # "cal":Ljava/util/Calendar;
    .end local v2    # "curCal":Ljava/util/Calendar;
    .end local v3    # "curDate":Ljava/util/Date;
    :cond_0
    :goto_0
    move v8, v0

    .line 218
    :goto_1
    return v8

    .restart local v1    # "cal":Ljava/util/Calendar;
    .restart local v2    # "curCal":Ljava/util/Calendar;
    .restart local v3    # "curDate":Ljava/util/Date;
    :cond_1
    move v0, v8

    .line 212
    goto :goto_0

    .line 215
    .end local v1    # "cal":Ljava/util/Calendar;
    .end local v2    # "curCal":Ljava/util/Calendar;
    .end local v3    # "curDate":Ljava/util/Date;
    :catch_0
    move-exception v6

    .line 217
    .local v6, "e":Ljava/text/ParseException;
    invoke-virtual {v6}, Ljava/text/ParseException;->printStackTrace()V

    goto :goto_1
.end method

.method Day2_Retention()V
    .locals 6

    .prologue
    .line 225
    :try_start_0
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    const-string v2, "844484708"

    const-string v3, "-EkgCKWtx3UQ5KDXkgM"

    const-string v4, "0.00"

    const/4 v5, 0x0

    invoke-static {v1, v2, v3, v4, v5}, Lcom/google/ads/conversiontracking/AdWordsConversionReporter;->reportWithConversionId(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 232
    :goto_0
    return-void

    .line 228
    :catch_0
    move-exception v0

    .line 230
    .local v0, "e":Ljava/lang/Exception;
    const-string v1, "IGGAdwordsHelper"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public HeroStage1_3()V
    .locals 7

    .prologue
    .line 164
    :try_start_0
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v3, "HEROSTAGE1_3_FLAG"

    invoke-virtual {v2, v3}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v0

    .line 165
    .local v0, "bHeroStage1_3Flag":Z
    if-nez v0, :cond_0

    .line 167
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v3, "HEROSTAGE1_3_FLAG"

    const/4 v4, 0x1

    invoke-virtual {v2, v3, v4}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 168
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->getActivity()Landroid/app/Activity;

    move-result-object v2

    const-string v3, "844484708"

    const-string v4, "mURfCIa0r3UQ5KDXkgM"

    const-string v5, "0.00"

    const/4 v6, 0x0

    invoke-static {v2, v3, v4, v5, v6}, Lcom/google/ads/conversiontracking/AdWordsConversionReporter;->reportWithConversionId(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 175
    .end local v0    # "bHeroStage1_3Flag":Z
    :cond_0
    :goto_0
    return-void

    .line 171
    :catch_0
    move-exception v1

    .line 173
    .local v1, "e":Ljava/lang/Exception;
    const-string v2, "IGGAdwordsHelper"

    invoke-virtual {v1}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public Install()V
    .locals 6

    .prologue
    .line 68
    :try_start_0
    const-string v3, "IGGAdwordsHelper"

    const-string v4, "Install"

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 69
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v4, "INSTALL_FLAG"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v2

    .line 70
    .local v2, "installFlag":Z
    const-string v3, "IGGAdwordsHelper"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "installFlag = "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 71
    if-nez v2, :cond_0

    .line 72
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v4, "INSTALL_FLAG"

    const/4 v5, 0x1

    invoke-virtual {v3, v4, v5}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 74
    new-instance v0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    sget-object v3, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-direct {v0, v3}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    .line 75
    .local v0, "adwordsEventReporter":Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;
    new-instance v3, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$1;

    invoke-direct {v3, p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$1;-><init>(Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;)V

    invoke-virtual {v0, v3}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->reportInstallation(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 91
    .end local v0    # "adwordsEventReporter":Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;
    .end local v2    # "installFlag":Z
    :cond_0
    :goto_0
    return-void

    .line 88
    :catch_0
    move-exception v1

    .line 89
    .local v1, "e":Ljava/lang/Exception;
    const-string v3, "IGGAdwordsHelper"

    invoke-virtual {v1}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public JoinGuild()V
    .locals 7

    .prologue
    .line 130
    :try_start_0
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v3, "JOIN_GUILD_FLAG"

    invoke-virtual {v2, v3}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v0

    .line 131
    .local v0, "bJoinGuildFlag":Z
    if-nez v0, :cond_0

    .line 133
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v3, "JOIN_GUILD_FLAG"

    const/4 v4, 0x1

    invoke-virtual {v2, v3, v4}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 134
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->getActivity()Landroid/app/Activity;

    move-result-object v2

    const-string v3, "844484708"

    const-string v4, "7afWCKe4x3UQ5KDXkgM"

    const-string v5, "0.00"

    const/4 v6, 0x0

    invoke-static {v2, v3, v4, v5, v6}, Lcom/google/ads/conversiontracking/AdWordsConversionReporter;->reportWithConversionId(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 141
    .end local v0    # "bJoinGuildFlag":Z
    :cond_0
    :goto_0
    return-void

    .line 137
    :catch_0
    move-exception v1

    .line 139
    .local v1, "e":Ljava/lang/Exception;
    const-string v2, "IGGAdwordsHelper"

    invoke-virtual {v1}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public Pay()V
    .locals 6

    .prologue
    .line 180
    :try_start_0
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    const-string v2, "844484708"

    const-string v3, "06hPCNazr3UQ5KDXkgM"

    const-string v4, "0.00"

    const/4 v5, 0x0

    invoke-static {v1, v2, v3, v4, v5}, Lcom/google/ads/conversiontracking/AdWordsConversionReporter;->reportWithConversionId(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 187
    :goto_0
    return-void

    .line 183
    :catch_0
    move-exception v0

    .line 185
    .local v0, "e":Ljava/lang/Exception;
    const-string v1, "IGGAdwordsHelper"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public ReachCastle5()V
    .locals 7

    .prologue
    .line 146
    :try_start_0
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v3, "REACH_CASTLE5_FLAG"

    invoke-virtual {v2, v3}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v0

    .line 147
    .local v0, "bReachCastle5Flag":Z
    if-nez v0, :cond_0

    .line 149
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v3, "REACH_CASTLE5_FLAG"

    const/4 v4, 0x1

    invoke-virtual {v2, v3, v4}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 150
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->getActivity()Landroid/app/Activity;

    move-result-object v2

    const-string v3, "844484708"

    const-string v4, "MbrwCPi3r3UQ5KDXkgM"

    const-string v5, "0.00"

    const/4 v6, 0x0

    invoke-static {v2, v3, v4, v5, v6}, Lcom/google/ads/conversiontracking/AdWordsConversionReporter;->reportWithConversionId(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 159
    .end local v0    # "bReachCastle5Flag":Z
    :cond_0
    :goto_0
    return-void

    .line 155
    :catch_0
    move-exception v1

    .line 157
    .local v1, "e":Ljava/lang/Exception;
    const-string v2, "IGGAdwordsHelper"

    invoke-virtual {v1}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public SingUp()V
    .locals 7

    .prologue
    .line 95
    :try_start_0
    const-string v4, "IGGAdwordsHelper"

    const-string v5, "SingUp"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 96
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v5, "SIGNUP_FLAG"

    invoke-virtual {v4, v5}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v3

    .line 97
    .local v3, "signUpFlag":Z
    if-nez v3, :cond_0

    .line 98
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v5, "SIGNUP_FLAG"

    const/4 v6, 0x1

    invoke-virtual {v4, v5, v6}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 100
    new-instance v0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    sget-object v4, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-direct {v0, v4}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    .line 102
    .local v0, "adwordsEventReporter":Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v4

    new-instance v5, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$2;

    invoke-direct {v5, p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$2;-><init>(Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;)V

    invoke-virtual {v0, v4, v5}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->reportSigningUp(Ljava/lang/String;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V

    .line 115
    .end local v0    # "adwordsEventReporter":Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;
    :cond_0
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v5, "DAY2_FLAG"

    invoke-virtual {v4, v5}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v1

    .line 116
    .local v1, "bDay2Flag":Z
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->CheckDay2()Z

    move-result v4

    if-eqz v4, :cond_1

    if-nez v1, :cond_1

    .line 118
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->storage:Lcom/igg/util/LocalStorage;

    const-string v5, "DAY2_FLAG"

    const/4 v6, 0x1

    invoke-virtual {v4, v5, v6}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 119
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->Day2_Retention()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 125
    .end local v1    # "bDay2Flag":Z
    .end local v3    # "signUpFlag":Z
    :cond_1
    :goto_0
    return-void

    .line 121
    :catch_0
    move-exception v2

    .line 122
    .local v2, "e":Ljava/lang/Exception;
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method
