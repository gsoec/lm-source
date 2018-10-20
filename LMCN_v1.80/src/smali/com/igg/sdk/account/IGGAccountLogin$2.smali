.class Lcom/igg/sdk/account/IGGAccountLogin$2;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->login(Lcom/igg/sdk/account/LoginListener;Lcom/igg/sdk/account/LoginDelegate;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$deviceStorageContent:Lcom/igg/sdk/IGGDeviceStorage;

.field final synthetic val$listener:Lcom/igg/sdk/account/LoginListener;

.field final synthetic val$stroageDeviceUIDStr:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Lcom/igg/sdk/IGGDeviceStorage;Lcom/igg/sdk/account/LoginListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 201
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$stroageDeviceUIDStr:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$deviceStorageContent:Lcom/igg/sdk/IGGDeviceStorage;

    iput-object p4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onRequestFinished(Ljava/lang/String;)V
    .locals 9
    .param p1, "advertisingId"    # Ljava/lang/String;

    .prologue
    const/4 v8, -0x1

    const/4 v7, 0x0

    .line 204
    if-eqz p1, :cond_1

    const-string v4, ""

    invoke-virtual {p1, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_1

    .line 205
    const-string v4, "IGGLogin"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "Delay gaid:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 206
    const-string v2, ""

    .line 207
    .local v2, "newDeviceUIDList":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$stroageDeviceUIDStr:Ljava/lang/String;

    const-string v5, ""

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_7

    .line 208
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$stroageDeviceUIDStr:Ljava/lang/String;

    const-string v5, "gaid="

    invoke-virtual {v4, v5}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v4

    if-ne v4, v8, :cond_2

    .line 209
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$stroageDeviceUIDStr:Ljava/lang/String;

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ","

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "gaid="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 233
    :cond_0
    :goto_0
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$deviceStorageContent:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v4, v2}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 234
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4, v2}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 241
    .end local v2    # "newDeviceUIDList":Ljava/lang/String;
    :cond_1
    :goto_1
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    new-instance v5, Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-direct {v5}, Lcom/igg/sdk/account/IGGDeviceGuest;-><init>()V

    iget-object v6, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-virtual {v4, v5, v6}, Lcom/igg/sdk/account/IGGAccountLogin;->loginAsGuest(Lcom/igg/sdk/account/IGGGuest;Lcom/igg/sdk/account/LoginListener;)V

    .line 242
    return-void

    .line 211
    .restart local v2    # "newDeviceUIDList":Ljava/lang/String;
    :cond_2
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$stroageDeviceUIDStr:Ljava/lang/String;

    const-string v5, ","

    invoke-virtual {v4, v5}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v4

    if-ne v4, v8, :cond_4

    .line 212
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$stroageDeviceUIDStr:Ljava/lang/String;

    const-string v5, "="

    invoke-virtual {v4, v5}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    .line 213
    .local v0, "ary":[Ljava/lang/String;
    aget-object v4, v0, v7

    if-eqz v4, :cond_3

    aget-object v4, v0, v7

    const-string v5, "gaid"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_3

    .line 214
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "gaid="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    goto :goto_0

    .line 216
    :cond_3
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ",gaid="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    goto :goto_0

    .line 218
    .end local v0    # "ary":[Ljava/lang/String;
    :cond_4
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$stroageDeviceUIDStr:Ljava/lang/String;

    const-string v5, ","

    invoke-virtual {v4, v5}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v4

    if-eq v4, v8, :cond_0

    .line 219
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$stroageDeviceUIDStr:Ljava/lang/String;

    const-string v5, ","

    invoke-virtual {v4, v5}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    .line 220
    .restart local v0    # "ary":[Ljava/lang/String;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_2
    array-length v4, v0

    if-ge v1, v4, :cond_6

    .line 221
    aget-object v4, v0, v1

    const-string v5, "="

    invoke-virtual {v4, v5}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v3

    .line 222
    .local v3, "str":[Ljava/lang/String;
    aget-object v4, v3, v7

    if-eqz v4, :cond_5

    aget-object v4, v3, v7

    const-string v5, "gaid"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_5

    .line 223
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "gaid="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ","

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 220
    :goto_3
    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    .line 225
    :cond_5
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    aget-object v5, v0, v1

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ","

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    goto :goto_3

    .line 229
    .end local v3    # "str":[Ljava/lang/String;
    :cond_6
    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v4

    add-int/lit8 v4, v4, -0x1

    invoke-virtual {v2, v7, v4}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v2

    goto/16 :goto_0

    .line 236
    .end local v0    # "ary":[Ljava/lang/String;
    .end local v1    # "i":I
    :cond_7
    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$2;->val$deviceStorageContent:Lcom/igg/sdk/IGGDeviceStorage;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "gaid="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 237
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "gaid="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    goto/16 :goto_1
.end method
