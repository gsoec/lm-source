.class public Lcom/appsflyer/share/LinkGenerator;
.super Ljava/lang/Object;
.source ""


# instance fields
.field private ʻ:Ljava/lang/String;

.field private ʼ:Ljava/lang/String;

.field private ʽ:Ljava/lang/String;

.field private ˊ:Ljava/lang/String;

.field private ˊॱ:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private ˋ:Ljava/lang/String;

.field private ˎ:Ljava/lang/String;

.field private ˏ:Ljava/lang/String;

.field private ͺ:Ljava/lang/String;

.field private ॱ:Ljava/lang/String;

.field private ॱˊ:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private ॱॱ:Ljava/lang/String;

.field private ᐝ:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 41
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 37
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    .line 38
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    .line 42
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ˎ:Ljava/lang/String;

    .line 43
    return-void
.end method

.method private static ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 229
    :try_start_0
    const-string v0, "utf8"

    invoke-static {p0, v0}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    move-result-object v0

    .line 235
    :goto_0
    return-object v0

    .line 231
    :catch_0
    move-exception v0

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "Illegal "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ": "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 232
    const-string v0, ""

    goto :goto_0

    .line 235
    :catch_1
    move-exception v0

    const-string v0, ""

    goto :goto_0
.end method

.method private ॱ()Ljava/lang/StringBuilder;
    .locals 7

    .prologue
    const/16 v6, 0x26

    .line 145
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    .line 147
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ᐝ:Ljava/lang/String;

    if-eqz v0, :cond_a

    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ᐝ:Ljava/lang/String;

    const-string v1, "http"

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_a

    .line 148
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ᐝ:Ljava/lang/String;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 154
    :goto_0
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ʽ:Ljava/lang/String;

    if-eqz v0, :cond_0

    .line 155
    const/16 v0, 0x2f

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ʽ:Ljava/lang/String;

    .line 156
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 159
    :cond_0
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    const-string v1, "pid"

    iget-object v3, p0, Lcom/appsflyer/share/LinkGenerator;->ˎ:Ljava/lang/String;

    invoke-interface {v0, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 161
    const/16 v0, 0x3f

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "pid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 162
    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ˎ:Ljava/lang/String;

    const-string v3, "media source"

    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 164
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱ:Ljava/lang/String;

    if-eqz v0, :cond_1

    .line 165
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    const-string v1, "af_referrer_uid"

    iget-object v3, p0, Lcom/appsflyer/share/LinkGenerator;->ॱ:Ljava/lang/String;

    invoke-interface {v0, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 166
    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "af_referrer_uid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 167
    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ॱ:Ljava/lang/String;

    const-string v3, "referrerUID"

    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 169
    :cond_1
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˏ:Ljava/lang/String;

    if-eqz v0, :cond_2

    .line 170
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    const-string v1, "af_channel"

    iget-object v3, p0, Lcom/appsflyer/share/LinkGenerator;->ˏ:Ljava/lang/String;

    invoke-interface {v0, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 171
    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "af_channel="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 172
    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ˏ:Ljava/lang/String;

    const-string v3, "channel"

    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 174
    :cond_2
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˊ:Ljava/lang/String;

    if-eqz v0, :cond_3

    .line 175
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    const-string v1, "af_referrer_customer_id"

    iget-object v3, p0, Lcom/appsflyer/share/LinkGenerator;->ˊ:Ljava/lang/String;

    invoke-interface {v0, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 176
    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "af_referrer_customer_id="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 177
    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ˊ:Ljava/lang/String;

    const-string v3, "referrerCustomerId"

    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 179
    :cond_3
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˋ:Ljava/lang/String;

    if-eqz v0, :cond_4

    .line 180
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    const-string v1, "c"

    iget-object v3, p0, Lcom/appsflyer/share/LinkGenerator;->ˋ:Ljava/lang/String;

    invoke-interface {v0, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 181
    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "c="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 182
    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ˋ:Ljava/lang/String;

    const-string v3, "campaign"

    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 184
    :cond_4
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱॱ:Ljava/lang/String;

    if-eqz v0, :cond_5

    .line 185
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    const-string v1, "af_referrer_name"

    iget-object v3, p0, Lcom/appsflyer/share/LinkGenerator;->ॱॱ:Ljava/lang/String;

    invoke-interface {v0, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 186
    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "af_referrer_name="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 187
    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ॱॱ:Ljava/lang/String;

    const-string v3, "referrerName"

    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 189
    :cond_5
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ʻ:Ljava/lang/String;

    if-eqz v0, :cond_6

    .line 190
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    const-string v1, "af_referrer_image_url"

    iget-object v3, p0, Lcom/appsflyer/share/LinkGenerator;->ʻ:Ljava/lang/String;

    invoke-interface {v0, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 191
    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "af_referrer_image_url="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 192
    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ʻ:Ljava/lang/String;

    const-string v3, "referrerImageURL"

    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 195
    :cond_6
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ͺ:Ljava/lang/String;

    if-eqz v0, :cond_8

    .line 196
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ͺ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    .line 197
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ͺ:Ljava/lang/String;

    const-string v3, "/"

    invoke-virtual {v0, v3}, Ljava/lang/String;->endsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_b

    const-string v0, ""

    :goto_1
    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 198
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ʼ:Ljava/lang/String;

    if-eqz v0, :cond_7

    .line 199
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ʼ:Ljava/lang/String;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 203
    :cond_7
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    const-string v3, "af_dp"

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-interface {v0, v3, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 206
    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "af_dp="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 207
    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ͺ:Ljava/lang/String;

    const-string v3, "baseDeeplink"

    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 209
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ʼ:Ljava/lang/String;

    if-eqz v0, :cond_8

    .line 210
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ͺ:Ljava/lang/String;

    const-string v1, "/"

    invoke-virtual {v0, v1}, Ljava/lang/String;->endsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_c

    const-string v0, ""

    :goto_2
    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ʼ:Ljava/lang/String;

    const-string v3, "deeplinkPath"

    .line 211
    invoke-static {v1, v3}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 215
    :cond_8
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->keySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :cond_9
    :goto_3
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_d

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 217
    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v5, "="

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    invoke-interface {v1, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    invoke-static {v1, v0}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v5, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v4, v1}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_9

    .line 221
    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const/16 v4, 0x3d

    .line 222
    invoke-virtual {v1, v4}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v1, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    invoke-interface {v1, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    invoke-static {v1, v0}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_3

    .line 151
    :cond_a
    const-string v0, "https://app.%s"

    invoke-static {v0}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto/16 :goto_0

    .line 197
    :cond_b
    const-string v0, "/"

    goto/16 :goto_1

    .line 210
    :cond_c
    const-string v0, "%2F"

    goto/16 :goto_2

    .line 224
    :cond_d
    return-object v2
.end method


# virtual methods
.method public addParameter(Ljava/lang/String;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 1

    .prologue
    .line 97
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    invoke-interface {v0, p1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 98
    return-object p0
.end method

.method public addParameters(Ljava/util/Map;)Lcom/appsflyer/share/LinkGenerator;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/appsflyer/share/LinkGenerator;"
        }
    .end annotation

    .prologue
    .line 102
    if-eqz p1, :cond_0

    .line 103
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->putAll(Ljava/util/Map;)V

    .line 105
    :cond_0
    return-object p0
.end method

.method public generateLink()Ljava/lang/String;
    .locals 1

    .prologue
    .line 240
    invoke-direct {p0}, Lcom/appsflyer/share/LinkGenerator;->ॱ()Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public generateLink(Landroid/content/Context;Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;)V
    .locals 5

    .prologue
    .line 245
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "oneLinkSlug"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 247
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_0

    .line 248
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    .line 249
    iget-object v3, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v4

    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v0

    invoke-interface {v3, v4, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    .line 253
    :cond_0
    invoke-direct {p0}, Lcom/appsflyer/share/LinkGenerator;->ॱ()Ljava/lang/StringBuilder;

    .line 255
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ॱˊ:Ljava/util/Map;

    invoke-static {p1, v1, v0, p2}, Lcom/appsflyer/share/ShareInviteHelper;->generateUserInviteLink(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;)V

    .line 256
    return-void
.end method

.method public getCampaign()Ljava/lang/String;
    .locals 1

    .prologue
    .line 93
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˋ:Ljava/lang/String;

    return-object v0
.end method

.method public getChannel()Ljava/lang/String;
    .locals 1

    .prologue
    .line 71
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˏ:Ljava/lang/String;

    return-object v0
.end method

.method public getMediaSource()Ljava/lang/String;
    .locals 1

    .prologue
    .line 80
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˎ:Ljava/lang/String;

    return-object v0
.end method

.method public getParameters()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 84
    iget-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ˊॱ:Ljava/util/Map;

    return-object v0
.end method

.method public setBaseDeeplink(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 56
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ͺ:Ljava/lang/String;

    .line 57
    return-object p0
.end method

.method public setBaseURL(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 5

    .prologue
    const/4 v2, 0x2

    const/4 v4, 0x1

    const/4 v3, 0x0

    .line 127
    if-eqz p1, :cond_0

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v0

    if-gtz v0, :cond_1

    .line 128
    :cond_0
    const-string v0, "https://%s/%s"

    new-array v1, v2, [Ljava/lang/Object;

    const-string v2, "app.%s"

    invoke-static {v2}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    aput-object v2, v1, v3

    aput-object p3, v1, v4

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ᐝ:Ljava/lang/String;

    .line 132
    :goto_0
    return-object p0

    .line 3136
    :cond_1
    if-eqz p2, :cond_2

    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result v0

    const/4 v1, 0x5

    if-ge v0, v1, :cond_3

    .line 3137
    :cond_2
    const-string p2, "go.onelink.me"

    .line 3139
    :cond_3
    const-string v0, "https://%s/%s"

    new-array v1, v2, [Ljava/lang/Object;

    aput-object p2, v1, v3

    aput-object p1, v1, v4

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 130
    iput-object v0, p0, Lcom/appsflyer/share/LinkGenerator;->ᐝ:Ljava/lang/String;

    goto :goto_0
.end method

.method public setCampaign(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 88
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ˋ:Ljava/lang/String;

    .line 89
    return-object p0
.end method

.method public setChannel(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 66
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ˏ:Ljava/lang/String;

    .line 67
    return-object p0
.end method

.method public setDeeplinkPath(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 51
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ʼ:Ljava/lang/String;

    .line 52
    return-object p0
.end method

.method public setReferrerCustomerId(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 75
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ˊ:Ljava/lang/String;

    .line 76
    return-object p0
.end method

.method public setReferrerImageURL(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 121
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ʻ:Ljava/lang/String;

    .line 122
    return-object p0
.end method

.method public setReferrerName(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 115
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ॱॱ:Ljava/lang/String;

    .line 116
    return-object p0
.end method

.method public setReferrerUID(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 109
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ॱ:Ljava/lang/String;

    .line 110
    return-object p0
.end method

.method final ˎ(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 46
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ʽ:Ljava/lang/String;

    .line 47
    return-object p0
.end method

.method final ˏ(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 0

    .prologue
    .line 61
    iput-object p1, p0, Lcom/appsflyer/share/LinkGenerator;->ᐝ:Ljava/lang/String;

    .line 62
    return-object p0
.end method
