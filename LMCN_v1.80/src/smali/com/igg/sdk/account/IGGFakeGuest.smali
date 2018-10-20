.class public final Lcom/igg/sdk/account/IGGFakeGuest;
.super Lcom/igg/sdk/account/IGGGuest;
.source "IGGFakeGuest.java"


# static fields
.field public static final TAG:Ljava/lang/String; = "IGGFakeGuest"


# instance fields
.field protected domain:Ljava/lang/String;

.field protected subject:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "domain"    # Ljava/lang/String;
    .param p2, "subject"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 53
    invoke-direct {p0}, Lcom/igg/sdk/account/IGGGuest;-><init>()V

    .line 55
    invoke-virtual {p0, p1}, Lcom/igg/sdk/account/IGGFakeGuest;->setDomain(Ljava/lang/String;)V

    .line 56
    invoke-virtual {p0, p2}, Lcom/igg/sdk/account/IGGFakeGuest;->setSubject(Ljava/lang/String;)V

    .line 57
    return-void
.end method

.method public static quickCreate(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGFakeGuest;
    .locals 1
    .param p0, "domain"    # Ljava/lang/String;
    .param p1, "subject"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 42
    new-instance v0, Lcom/igg/sdk/account/IGGFakeGuest;

    invoke-direct {v0, p0, p1}, Lcom/igg/sdk/account/IGGFakeGuest;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    return-object v0
.end method


# virtual methods
.method public getDomain()Ljava/lang/String;
    .locals 1

    .prologue
    .line 101
    iget-object v0, p0, Lcom/igg/sdk/account/IGGFakeGuest;->domain:Ljava/lang/String;

    return-object v0
.end method

.method public getIdentifier()Ljava/lang/String;
    .locals 4
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 112
    iget-object v1, p0, Lcom/igg/sdk/account/IGGFakeGuest;->identifier:Ljava/lang/String;

    if-nez v1, :cond_1

    .line 113
    invoke-virtual {p0}, Lcom/igg/sdk/account/IGGFakeGuest;->getReadableIdentifier()Ljava/lang/String;

    move-result-object v0

    .line 114
    .local v0, "source":Ljava/lang/String;
    if-nez v0, :cond_0

    .line 115
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "IGGSDK.sharedInstance().getDeviceRegisterId() return NULL"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 117
    :cond_0
    const-string v1, "IGGFakeGuest"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Source of identifier is: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 118
    new-instance v1, Lcom/igg/util/MD5;

    invoke-direct {v1}, Lcom/igg/util/MD5;-><init>()V

    invoke-virtual {v1, v0}, Lcom/igg/util/MD5;->getMD5ofStr(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    sget-object v2, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-virtual {v1, v2}, Ljava/lang/String;->toLowerCase(Ljava/util/Locale;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/sdk/account/IGGFakeGuest;->identifier:Ljava/lang/String;

    .line 121
    .end local v0    # "source":Ljava/lang/String;
    :cond_1
    iget-object v1, p0, Lcom/igg/sdk/account/IGGFakeGuest;->identifier:Ljava/lang/String;

    return-object v1
.end method

.method public getReadableIdentifier()Ljava/lang/String;
    .locals 6

    .prologue
    .line 129
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v0

    .line 130
    .local v0, "deviceIdentifier":Ljava/lang/String;
    const-string v1, "%s.%s.%s.%s"

    const/4 v2, 0x4

    new-array v2, v2, [Ljava/lang/Object;

    const/4 v3, 0x0

    iget-object v4, p0, Lcom/igg/sdk/account/IGGFakeGuest;->domain:Ljava/lang/String;

    aput-object v4, v2, v3

    const/4 v3, 0x1

    iget-object v4, p0, Lcom/igg/sdk/account/IGGFakeGuest;->subject:Ljava/lang/String;

    aput-object v4, v2, v3

    const/4 v3, 0x2

    aput-object v0, v2, v3

    const/4 v3, 0x3

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-static {v1, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    return-object v1
.end method

.method public getSubject()Ljava/lang/String;
    .locals 1

    .prologue
    .line 108
    iget-object v0, p0, Lcom/igg/sdk/account/IGGFakeGuest;->subject:Ljava/lang/String;

    return-object v0
.end method

.method public setDomain(Ljava/lang/String;)V
    .locals 3
    .param p1, "domain"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 69
    const-string v1, "^[a-z]{2,5}\\.[a-z0-9\\-]+$"

    const/4 v2, 0x2

    invoke-static {v1, v2}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;I)Ljava/util/regex/Pattern;

    move-result-object v0

    .line 71
    .local v0, "pattern":Ljava/util/regex/Pattern;
    invoke-virtual {v0, p1}, Ljava/util/regex/Pattern;->matcher(Ljava/lang/CharSequence;)Ljava/util/regex/Matcher;

    move-result-object v1

    invoke-virtual {v1}, Ljava/util/regex/Matcher;->find()Z

    move-result v1

    if-nez v1, :cond_0

    .line 72
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "Invalid domain with wrong format"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 75
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGFakeGuest;->domain:Ljava/lang/String;

    .line 76
    return-void
.end method

.method public setIdentifier(Ljava/lang/String;)V
    .locals 2
    .param p1, "identifier"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 125
    const-string v0, "IGGFakeGuest"

    const-string v1, "setIdentifier is not supported in IGGFreshFakeGuest"

    invoke-static {v0, v1}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 126
    return-void
.end method

.method public setSubject(Ljava/lang/String;)V
    .locals 3
    .param p1, "subject"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 88
    const-string v1, "^[a-z0-9\\-]+$"

    const/4 v2, 0x2

    invoke-static {v1, v2}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;I)Ljava/util/regex/Pattern;

    move-result-object v0

    .line 90
    .local v0, "pattern":Ljava/util/regex/Pattern;
    invoke-virtual {v0, p1}, Ljava/util/regex/Pattern;->matcher(Ljava/lang/CharSequence;)Ljava/util/regex/Matcher;

    move-result-object v1

    invoke-virtual {v1}, Ljava/util/regex/Matcher;->find()Z

    move-result v1

    if-nez v1, :cond_0

    .line 91
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "Invalid subject with wrong format"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 94
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGFakeGuest;->subject:Ljava/lang/String;

    .line 95
    return-void
.end method
