.class public Lcom/igg/sdk/IGGAppProfile;
.super Ljava/lang/Object;
.source "IGGAppProfile.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/IGGAppProfile$FieldListener;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGAppProfile"

.field private static instance:Lcom/igg/sdk/IGGAppProfile;


# instance fields
.field private initializedJustNow:Z

.field private storage:Lcom/igg/util/LocalStorage;


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 39
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 40
    new-instance v0, Lcom/igg/util/LocalStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v1

    const-string v2, "app_profile"

    invoke-direct {v0, v1, v2}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/sdk/IGGAppProfile;->storage:Lcom/igg/util/LocalStorage;

    .line 41
    return-void
.end method

.method private initializeCreatedAtField()V
    .locals 5

    .prologue
    .line 124
    const-string v0, "created_at"

    .line 126
    .local v0, "storageKey":Ljava/lang/String;
    iget-object v2, p0, Lcom/igg/sdk/IGGAppProfile;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v2, v0}, Lcom/igg/util/LocalStorage;->keyExists(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 127
    const/4 v2, 0x0

    iput-boolean v2, p0, Lcom/igg/sdk/IGGAppProfile;->initializedJustNow:Z

    .line 138
    :goto_0
    return-void

    .line 129
    :cond_0
    new-instance v2, Ljava/text/SimpleDateFormat;

    const-string v3, "yyyy-MM-dd HH:mm:ss"

    sget-object v4, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v2, v3, v4}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    new-instance v3, Ljava/util/Date;

    invoke-direct {v3}, Ljava/util/Date;-><init>()V

    invoke-virtual {v2, v3}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v1

    .line 130
    .local v1, "timeNow":Ljava/lang/String;
    iget-object v2, p0, Lcom/igg/sdk/IGGAppProfile;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v2, v0, v1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V

    .line 132
    const/4 v2, 0x1

    iput-boolean v2, p0, Lcom/igg/sdk/IGGAppProfile;->initializedJustNow:Z

    .line 133
    invoke-static {}, Lcom/igg/sdk/IGGNotificationCenter;->sharedInstance()Lcom/igg/sdk/IGGNotificationCenter;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/IGGNotification;

    const-string v4, "FIRST_START_UP"

    invoke-direct {v3, v4, p0}, Lcom/igg/sdk/IGGNotification;-><init>(Ljava/lang/String;Ljava/lang/Object;)V

    invoke-virtual {v2, v3}, Lcom/igg/sdk/IGGNotificationCenter;->postNotification(Lcom/igg/sdk/IGGNotification;)V

    goto :goto_0
.end method

.method public static sharedInstance()Lcom/igg/sdk/IGGAppProfile;
    .locals 1

    .prologue
    .line 27
    sget-object v0, Lcom/igg/sdk/IGGAppProfile;->instance:Lcom/igg/sdk/IGGAppProfile;

    if-nez v0, :cond_0

    .line 28
    new-instance v0, Lcom/igg/sdk/IGGAppProfile;

    invoke-direct {v0}, Lcom/igg/sdk/IGGAppProfile;-><init>()V

    sput-object v0, Lcom/igg/sdk/IGGAppProfile;->instance:Lcom/igg/sdk/IGGAppProfile;

    .line 31
    :cond_0
    sget-object v0, Lcom/igg/sdk/IGGAppProfile;->instance:Lcom/igg/sdk/IGGAppProfile;

    return-object v0
.end method


# virtual methods
.method public getLastLoginTime()Ljava/util/Date;
    .locals 4

    .prologue
    .line 66
    :try_start_0
    new-instance v1, Ljava/text/SimpleDateFormat;

    const-string v2, "yyyy-MM-dd HH:mm:ss"

    sget-object v3, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v1, v2, v3}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    iget-object v2, p0, Lcom/igg/sdk/IGGAppProfile;->storage:Lcom/igg/util/LocalStorage;

    const-string v3, "last_logined_time"

    invoke-virtual {v2, v3}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/text/SimpleDateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;
    :try_end_0
    .catch Ljava/text/ParseException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v1

    .line 69
    :goto_0
    return-object v1

    .line 67
    :catch_0
    move-exception v0

    .line 68
    .local v0, "e":Ljava/text/ParseException;
    invoke-virtual {v0}, Ljava/text/ParseException;->printStackTrace()V

    .line 69
    const/4 v1, 0x0

    goto :goto_0
.end method

.method public initialize()V
    .locals 2

    .prologue
    .line 47
    invoke-direct {p0}, Lcom/igg/sdk/IGGAppProfile;->initializeCreatedAtField()V

    .line 49
    const-string v0, "IGGAppProfile"

    const-string v1, "Finish initializing"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 50
    return-void
.end method

.method public isInitializedJustNow()Z
    .locals 1

    .prologue
    .line 109
    iget-boolean v0, p0, Lcom/igg/sdk/IGGAppProfile;->initializedJustNow:Z

    return v0
.end method

.method public setFieldWithEvents(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/IGGAppProfile$FieldListener;)V
    .locals 2
    .param p1, "name"    # Ljava/lang/String;
    .param p2, "value"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/IGGAppProfile$FieldListener;

    .prologue
    .line 174
    iget-object v1, p0, Lcom/igg/sdk/IGGAppProfile;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v1, p1}, Lcom/igg/util/LocalStorage;->keyExists(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 175
    iget-object v1, p0, Lcom/igg/sdk/IGGAppProfile;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v1, p1}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 176
    .local v0, "oldValue":Ljava/lang/String;
    iget-object v1, p0, Lcom/igg/sdk/IGGAppProfile;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v1, p1, p2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V

    .line 177
    invoke-interface {p3, v0, p2}, Lcom/igg/sdk/IGGAppProfile$FieldListener;->onUpdated(Ljava/lang/String;Ljava/lang/String;)V

    .line 182
    .end local v0    # "oldValue":Ljava/lang/String;
    :goto_0
    return-void

    .line 179
    :cond_0
    iget-object v1, p0, Lcom/igg/sdk/IGGAppProfile;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v1, p1, p2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V

    .line 180
    invoke-interface {p3, p2}, Lcom/igg/sdk/IGGAppProfile$FieldListener;->onAdded(Ljava/lang/String;)V

    goto :goto_0
.end method

.method public updateLastLoginTime()V
    .locals 4

    .prologue
    .line 80
    const-string v1, "IGGAppProfile"

    const-string v2, "The last login time is updated"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 82
    new-instance v1, Ljava/text/SimpleDateFormat;

    const-string v2, "yyyy-MM-dd HH:mm:ss"

    sget-object v3, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v1, v2, v3}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    new-instance v2, Ljava/util/Date;

    invoke-direct {v2}, Ljava/util/Date;-><init>()V

    invoke-virtual {v1, v2}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v0

    .line 84
    .local v0, "timeNow":Ljava/lang/String;
    const-string v1, "last_logined_time"

    new-instance v2, Lcom/igg/sdk/IGGAppProfile$1;

    invoke-direct {v2, p0}, Lcom/igg/sdk/IGGAppProfile$1;-><init>(Lcom/igg/sdk/IGGAppProfile;)V

    invoke-virtual {p0, v1, v0, v2}, Lcom/igg/sdk/IGGAppProfile;->setFieldWithEvents(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/IGGAppProfile$FieldListener;)V

    .line 98
    return-void
.end method
