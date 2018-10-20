.class public Lcom/ta/utdid2/aid/b;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/ta/utdid2/aid/b$a;
    }
.end annotation


# static fields
.field public static final a:Ljava/lang/String;

.field private static final b:Ljava/lang/String; = "http://hydra.alibaba.com/"

.field private static final c:Ljava/lang/String; = "/get_aid/"

.field private static final d:Ljava/lang/String; = "auth[token]="

.field private static final e:Ljava/lang/String; = "&type="

.field private static final f:Ljava/lang/String; = "&id="

.field private static final g:Ljava/lang/String; = "&aid="

.field private static final h:Ljava/lang/String; = "data"

.field private static final i:Ljava/lang/String; = "aid"

.field private static final j:Ljava/lang/String; = "action"

.field private static final k:Ljava/lang/String; = "isError"

.field private static final l:Ljava/lang/String; = "status"

.field private static final m:Ljava/lang/String; = "utdid"

.field private static final n:Ljava/lang/String; = "new"

.field private static final o:Ljava/lang/String; = "changed"

.field private static final p:Ljava/lang/String; = "unchanged"

.field private static final q:Ljava/lang/String; = "true"

.field private static final r:Ljava/lang/String; = "false"

.field private static final s:Ljava/lang/String; = "200"

.field private static final t:Ljava/lang/String; = "404"

.field private static final u:Ljava/lang/String; = "401"

.field private static final v:I = 0x3e8

.field private static final w:I = 0xbb8

.field private static x:Lcom/ta/utdid2/aid/b;


# instance fields
.field private y:Landroid/content/Context;

.field private z:Ljava/lang/Object;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 30
    const-class v0, Lcom/ta/utdid2/aid/b;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    .line 64
    const/4 v0, 0x0

    sput-object v0, Lcom/ta/utdid2/aid/b;->x:Lcom/ta/utdid2/aid/b;

    return-void
.end method

.method private constructor <init>(Landroid/content/Context;)V
    .locals 1

    .prologue
    .line 175
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 67
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    iput-object v0, p0, Lcom/ta/utdid2/aid/b;->z:Ljava/lang/Object;

    .line 176
    iput-object p1, p0, Lcom/ta/utdid2/aid/b;->y:Landroid/content/Context;

    .line 177
    return-void
.end method

.method public static declared-synchronized a(Landroid/content/Context;)Lcom/ta/utdid2/aid/b;
    .locals 2

    .prologue
    .line 168
    const-class v1, Lcom/ta/utdid2/aid/b;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/ta/utdid2/aid/b;->x:Lcom/ta/utdid2/aid/b;

    if-nez v0, :cond_0

    .line 169
    new-instance v0, Lcom/ta/utdid2/aid/b;

    invoke-direct {v0, p0}, Lcom/ta/utdid2/aid/b;-><init>(Landroid/content/Context;)V

    sput-object v0, Lcom/ta/utdid2/aid/b;->x:Lcom/ta/utdid2/aid/b;

    .line 172
    :cond_0
    sget-object v0, Lcom/ta/utdid2/aid/b;->x:Lcom/ta/utdid2/aid/b;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v1

    return-object v0

    .line 168
    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method

.method static synthetic a(Lcom/ta/utdid2/aid/b;)Ljava/lang/Object;
    .locals 1

    .prologue
    .line 67
    iget-object v0, p0, Lcom/ta/utdid2/aid/b;->z:Ljava/lang/Object;

    return-object v0
.end method

.method static synthetic a()Ljava/lang/String;
    .locals 1

    .prologue
    .line 30
    sget-object v0, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    return-object v0
.end method

.method static synthetic a(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    .prologue
    .line 221
    invoke-static {p0, p1}, Lcom/ta/utdid2/aid/b;->b(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/ut/device/a;)V
    .locals 7

    .prologue
    .line 181
    invoke-static {p1, p2, p3, p4}, Lcom/ta/utdid2/aid/b;->b(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 182
    sget-boolean v1, Lcom/ta/utdid2/android/utils/d;->a:Z

    if-eqz v1, :cond_0

    .line 183
    sget-object v1, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "url:"

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "; len:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 185
    :cond_0
    new-instance v2, Lorg/apache/http/client/methods/HttpPost;

    invoke-direct {v2, v0}, Lorg/apache/http/client/methods/HttpPost;-><init>(Ljava/lang/String;)V

    .line 187
    new-instance v0, Lcom/ta/utdid2/aid/b$a;

    move-object v1, p0

    move-object v3, p5

    move-object v4, p4

    move-object v5, p1

    move-object v6, p2

    invoke-direct/range {v0 .. v6}, Lcom/ta/utdid2/aid/b$a;-><init>(Lcom/ta/utdid2/aid/b;Lorg/apache/http/client/methods/HttpPost;Lcom/ut/device/a;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 188
    invoke-virtual {v0}, Lcom/ta/utdid2/aid/b$a;->start()V

    .line 189
    return-void
.end method

.method static synthetic b(Lcom/ta/utdid2/aid/b;)Landroid/content/Context;
    .locals 1

    .prologue
    .line 65
    iget-object v0, p0, Lcom/ta/utdid2/aid/b;->y:Landroid/content/Context;

    return-object v0
.end method

.method private static b(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 4

    .prologue
    .line 223
    invoke-static {p0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 227
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 228
    const-string v1, "data"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_2

    .line 229
    const-string v1, "data"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v0

    .line 232
    const-string v1, "action"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    const-string v1, "aid"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 233
    const-string v1, "action"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 234
    const-string v2, "new"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_0

    .line 235
    const-string v2, "changed"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 236
    :cond_0
    const-string v1, "aid"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    .line 262
    :cond_1
    :goto_0
    return-object p1

    .line 241
    :cond_2
    const-string v1, "isError"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    const-string v1, "status"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 243
    const-string v1, "isError"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 244
    const-string v2, "status"

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 246
    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 247
    const-string v1, "404"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_3

    .line 248
    const-string v1, "401"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 249
    :cond_3
    sget-boolean v1, Lcom/ta/utdid2/android/utils/d;->a:Z

    if-eqz v1, :cond_4

    .line 250
    sget-object v1, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "remove the AID, status:"

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 252
    :cond_4
    const-string p1, ""
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1

    goto :goto_0

    .line 256
    :catch_0
    move-exception v0

    .line 257
    sget-object v1, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    invoke-virtual {v0}, Lorg/json/JSONException;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 258
    :catch_1
    move-exception v0

    .line 259
    sget-object v1, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public static b(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 267
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    .line 273
    :try_start_0
    const-string v0, "UTF-8"

    invoke-static {p2, v0}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object p2

    .line 280
    :goto_0
    const-string v0, "http://hydra.alibaba.com/"

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "/get_aid/?auth[token]="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 281
    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 282
    const-string v1, "&type=utdid&id="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 283
    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 284
    const-string v1, "&aid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 280
    return-object v0

    .line 275
    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/io/UnsupportedEncodingException;->printStackTrace()V

    goto :goto_0
.end method


# virtual methods
.method public final a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 6

    .prologue
    .line 194
    invoke-static {p1, p2, p3, p4}, Lcom/ta/utdid2/aid/b;->b(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 195
    iget-object v0, p0, Lcom/ta/utdid2/aid/b;->y:Landroid/content/Context;

    invoke-static {v0}, Lcom/ta/utdid2/android/utils/f;->b(Landroid/content/Context;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 196
    const/16 v0, 0xbb8

    .line 198
    :goto_0
    sget-boolean v2, Lcom/ta/utdid2/android/utils/d;->a:Z

    if-eqz v2, :cond_0

    .line 199
    sget-object v2, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    new-instance v3, Ljava/lang/StringBuilder;

    const-string v4, "url:"

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "; timeout:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 201
    :cond_0
    new-instance v2, Lorg/apache/http/client/methods/HttpPost;

    invoke-direct {v2, v1}, Lorg/apache/http/client/methods/HttpPost;-><init>(Ljava/lang/String;)V

    .line 203
    new-instance v1, Lcom/ta/utdid2/aid/b$a;

    invoke-direct {v1, p0, v2}, Lcom/ta/utdid2/aid/b$a;-><init>(Lcom/ta/utdid2/aid/b;Lorg/apache/http/client/methods/HttpPost;)V

    .line 204
    invoke-virtual {v1}, Lcom/ta/utdid2/aid/b$a;->start()V

    .line 206
    :try_start_0
    iget-object v2, p0, Lcom/ta/utdid2/aid/b;->z:Ljava/lang/Object;

    monitor-enter v2
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 207
    :try_start_1
    iget-object v3, p0, Lcom/ta/utdid2/aid/b;->z:Ljava/lang/Object;

    int-to-long v4, v0

    invoke-virtual {v3, v4, v5}, Ljava/lang/Object;->wait(J)V

    .line 206
    monitor-exit v2
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 1163
    :goto_1
    iget-object v0, v1, Lcom/ta/utdid2/aid/b$a;->b:Ljava/lang/String;

    .line 213
    sget-boolean v1, Lcom/ta/utdid2/android/utils/d;->a:Z

    if-eqz v1, :cond_1

    .line 214
    sget-object v1, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "mLine:"

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 216
    :cond_1
    invoke-static {v0, p4}, Lcom/ta/utdid2/aid/b;->b(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 218
    return-object v0

    .line 196
    :cond_2
    const/16 v0, 0x3e8

    goto :goto_0

    .line 206
    :catchall_0
    move-exception v0

    :try_start_2
    monitor-exit v2
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    :try_start_3
    throw v0
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_0

    .line 209
    :catch_0
    move-exception v0

    .line 210
    sget-object v2, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v2, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1
.end method
